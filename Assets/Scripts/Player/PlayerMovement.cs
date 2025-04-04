using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;

public class PlayerMovement : MonoBehaviour
{
    public SPUM_Prefabs _prefabs;
   public Camera mainCamera;
    private PlayerState _currentState;

    public Dictionary<PlayerState, int> IndexPair = new();
    public GameObject unitRoot;
    public GameObject l_Weapon;
    public Vector3 characterPos;
    private Vector3 _movementInput;

    void Start()
    {
        transform.localScale = PlayerStats.PlayerScale;
        if (_prefabs == null)
        {
            _prefabs = transform.GetChild(0).GetComponent<SPUM_Prefabs>();
            if (!_prefabs.allListsHaveItemsExist())
            {
                _prefabs.PopulateAnimationLists();
            }
        }

        _prefabs.OverrideControllerInit();

        foreach (PlayerState state in Enum.GetValues(typeof(PlayerState)))
        {
            IndexPair[state] = 0;
        }
        
        _currentState = PlayerState.IDLE;
    }



    public void PlayStateAnimation(PlayerState state)
    {
        _prefabs.PlayAnimation(state, IndexPair[state]);
    }

    void Update()
    {
        HandleInput();
        HandleMovement();
        TurnToMousePosition();
        PlayStateAnimation(_currentState);
    }

    void HandleInput()
    {
        _movementInput = new Vector3(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"), 0);

        if (_movementInput.sqrMagnitude > 0)
        {
            _currentState = PlayerState.MOVE;
        }
        else
        {
            _currentState = PlayerState.IDLE;
        }
    }
    void TurnToMousePosition()
{
    if (mainCamera == null)
    {
        //Debug.LogWarning("Main Camera is null! Assign the mainCamera in the Inspector.");
        return;
    }

    characterPos = transform.position;

    Ray ray = mainCamera.ScreenPointToRay(Input.mousePosition);
    Plane plane = new Plane(Vector3.forward, characterPos);
    
    if (plane.Raycast(ray, out float distance))
    {
        Vector3 worldMousePos = ray.GetPoint(distance);

        if (unitRoot != null)
        {
            if (worldMousePos.x > characterPos.x)
            {
                unitRoot.transform.localScale = new Vector3(-Mathf.Abs(unitRoot.transform.localScale.x), unitRoot.transform.localScale.y, unitRoot.transform.localScale.z);
            }
            else if (worldMousePos.x < characterPos.x)
            {
                unitRoot.transform.localScale = new Vector3(Mathf.Abs(unitRoot.transform.localScale.x), unitRoot.transform.localScale.y, unitRoot.transform.localScale.z);
            }
        }
        else
        {
            Debug.LogWarning("unitRoot is null! Assign the unitRoot GameObject in the Inspector.");
        }

       
    }
}


    void HandleMovement()
    {
        if (_currentState == PlayerState.MOVE)
        {
            Vector3 direction = _movementInput.normalized;
            transform.position += direction * PlayerStats.PlayerMovementSpeed * Time.deltaTime;
        }
    }
}
