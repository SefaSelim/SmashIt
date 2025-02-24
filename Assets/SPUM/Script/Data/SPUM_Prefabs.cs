using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.Events;
using System.Linq;
public enum PlayerState
{
    IDLE,
    MOVE,
    ATTACK,
    DAMAGED,
    DEBUFF,
    DEATH,
    OTHER,
}
public class SPUM_Prefabs : MonoBehaviour
{
    public float _version;
    public bool EditChk;
    public string _code;
    public Animator _anim;
    private AnimatorOverrideController OverrideController;

    public string UnitType;
    public List<SpumPackage> spumPackages = new List<SpumPackage>();
    public List<PreviewMatchingElement> ImageElement = new();
    public List<SPUM_AnimationData> SpumAnimationData = new();
    public Dictionary<string, List<AnimationClip>> StateAnimationPairs = new();
    public List<AnimationClip> IDLE_List = new();
    public List<AnimationClip> MOVE_List = new();
    public List<AnimationClip> ATTACK_List = new();
    public List<AnimationClip> DAMAGED_List = new();
    public List<AnimationClip> DEBUFF_List = new();
    public List<AnimationClip> DEATH_List = new();
    public List<AnimationClip> OTHER_List = new();
   public void OverrideControllerInit()
{   
    if (_anim == null)
    {
        Debug.LogError("Animator component is missing.");
        return;
    }

    if (_anim.runtimeAnimatorController == null)
    {
        Debug.LogError("Animator does not have a runtimeAnimatorController assigned.");
        return;
    }

    // Yeni OverrideController oluştur ve temel animator controller'ı ata
    OverrideController = new AnimatorOverrideController(_anim.runtimeAnimatorController);

    // RuntimeAnimatorController'dan tüm animasyon kliplerini al
    AnimationClip[] clips = OverrideController.animationClips;
    
    if (clips.Length == 0)
    {
        Debug.LogWarning("No animation clips found in the Animator Controller.");
        return;
    }

    // OverrideController'a klipleri ekle
    foreach (AnimationClip clip in clips)
    {
        OverrideController[clip.name] = clip;
    }

    // Animator'daki runtimeAnimatorController'ı OverrideController ile değiştir
    _anim.runtimeAnimatorController = OverrideController;

    // StateAnimationPairs için animasyon listelerini eşle
    foreach (PlayerState state in Enum.GetValues(typeof(PlayerState)))
    {
        var stateText = state.ToString();
        StateAnimationPairs[stateText] = new List<AnimationClip>();

        switch (state)
        {
            case PlayerState.IDLE:
                StateAnimationPairs[stateText] = IDLE_List;
                break;
            case PlayerState.MOVE:
                StateAnimationPairs[stateText] = MOVE_List;
                break;
            case PlayerState.ATTACK:
                StateAnimationPairs[stateText] = ATTACK_List;
                break;
            case PlayerState.DAMAGED:
                StateAnimationPairs[stateText] = DAMAGED_List;
                break;
            case PlayerState.DEBUFF:
                StateAnimationPairs[stateText] = DEBUFF_List;
                break;
            case PlayerState.DEATH:
                StateAnimationPairs[stateText] = DEATH_List;
                break;
            case PlayerState.OTHER:
                StateAnimationPairs[stateText] = OTHER_List;
                break;
        }
    }

    Debug.Log("OverrideController successfully initialized.");
}

    public bool allListsHaveItemsExist(){
        List<List<AnimationClip>> allLists = new List<List<AnimationClip>>()
        {
            IDLE_List, MOVE_List, ATTACK_List, DAMAGED_List, DEBUFF_List, DEATH_List, OTHER_List
        };

        return allLists.All(list => list.Count > 0);
    }
    [ContextMenu("PopulateAnimationLists")]
    public void PopulateAnimationLists()
    {
        IDLE_List = new();
        MOVE_List = new();
        ATTACK_List = new();
        DAMAGED_List = new();
        DEBUFF_List = new();
        DEATH_List = new();
        OTHER_List = new();
        
        var groupedClips = spumPackages
        .SelectMany(package => package.SpumAnimationData)
        .Where(spumClip => spumClip.HasData && 
                        spumClip.UnitType.Equals(UnitType) && 
                        spumClip.index > -1 )
        .GroupBy(spumClip => spumClip.StateType)
        .ToDictionary(
            group => group.Key, 
            group => group.OrderBy(clip => clip.index).ToList()
        );
    // foreach (var item in groupedClips)
    // {
    //     foreach (var clip in item.Value)
    //     {
    //         Debug.Log(clip.ClipPath);
    //     }
    // }
        foreach (var kvp in groupedClips)
        {
            var stateType = kvp.Key;
            var orderedClips = kvp.Value;
            switch (stateType)
            {
                case "IDLE":
                    IDLE_List.AddRange(orderedClips.Select(clip => LoadAnimationClip(clip.ClipPath)));
                    //StateAnimationPairs[stateType] = IDLE_List;
                    break;
                case "MOVE":
                    MOVE_List.AddRange(orderedClips.Select(clip => LoadAnimationClip(clip.ClipPath)));
                    //StateAnimationPairs[stateType] = MOVE_List;
                    break;
                case "ATTACK":
                    ATTACK_List.AddRange(orderedClips.Select(clip => LoadAnimationClip(clip.ClipPath)));
                    //StateAnimationPairs[stateType] = ATTACK_List;
                    break;
                case "DAMAGED":
                    DAMAGED_List.AddRange(orderedClips.Select(clip => LoadAnimationClip(clip.ClipPath)));
                    //StateAnimationPairs[stateType] = DAMAGED_List;
                    break;
                case "DEBUFF":
                    DEBUFF_List.AddRange(orderedClips.Select(clip => LoadAnimationClip(clip.ClipPath)));
                    //StateAnimationPairs[stateType] = DEBUFF_List;
                    break;
                case "DEATH":
                    DEATH_List.AddRange(orderedClips.Select(clip => LoadAnimationClip(clip.ClipPath)));
                    //StateAnimationPairs[stateType] = DEATH_List;
                    break;
                case "OTHER":
                    OTHER_List.AddRange(orderedClips.Select(clip => LoadAnimationClip(clip.ClipPath)));
                    //StateAnimationPairs[stateType] = OTHER_List;
                    break;
            }
        }
    
    }
    public void PlayAnimation(PlayerState PlayState, int index){
        Animator animator = _anim;
        //Debug.Log(PlayState.ToString());
        var animations =  StateAnimationPairs[PlayState.ToString()];
        //Debug.Log(OverrideController[PlayState.ToString()].name);
        OverrideController[PlayState.ToString()] = animations[index];
        //Debug.Log( OverrideController[PlayState.ToString()].name);
        var StateStr = PlayState.ToString();
   
        bool isMove = StateStr.Contains("MOVE");
        bool isDebuff = StateStr.Contains("DEBUFF");
        bool isDeath = StateStr.Contains("DEATH");
        animator.SetBool("1_Move", isMove);
        animator.SetBool("5_Debuff", isDebuff);
        animator.SetBool("isDeath", isDeath);
        if(!isMove && !isDebuff)
        {
            AnimatorControllerParameter[] parameters = animator.parameters;
            foreach (AnimatorControllerParameter parameter in parameters)
            {
                // if(parameter.type == AnimatorControllerParameterType.Bool){
                //     bool isBool = StateStr.ToUpper().Contains(parameter.name.ToUpper());
                //     animator.SetBool(parameter.name, isBool);
                // }
                if(parameter.type == AnimatorControllerParameterType.Trigger)
                {
                    bool isTrigger = parameter.name.ToUpper().Contains(StateStr.ToUpper());
                    if(isTrigger){
                         Debug.Log($"Parameter: {parameter.name}, Type: {parameter.type}");
                        animator.SetTrigger(parameter.name);
                    }
                }
            }
        }
    }
    AnimationClip LoadAnimationClip(string clipPath)
    {
        // "Animations" 폴더에서 애니메이션 클립 로드
        AnimationClip clip = Resources.Load<AnimationClip>(clipPath.Replace(".anim", ""));
        
        if (clip == null)
        {
            Debug.LogWarning($"Failed to load animation clip '{clipPath}'.");
        }
        
        return clip;
    }
}
