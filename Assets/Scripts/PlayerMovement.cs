using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;

public class PlayerMovement : MonoBehaviour
{
    public SPUM_Prefabs _prefabs;
    public float PlayerMovementSpeed = 4f;
    private PlayerState _currentState;

    public Dictionary<PlayerState, int> IndexPair = new();

    public Vector3 characterPos;
    private Vector3 _movementInput;

    void Start()
    {

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
    void TurnToMousePosition() // Karakterin yönünü ayarlar
    {   
        characterPos = this.transform.position;
        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        if (mousePos.x > characterPos.x)
            _prefabs.transform.localScale = new Vector3(-1 * Math.Abs(_prefabs.transform.localScale.x), _prefabs.transform.localScale.y , _prefabs.transform.localPosition.z);

        else if (mousePos.x < characterPos.x)
            _prefabs.transform.localScale = new Vector3( Math.Abs(_prefabs.transform.localScale.x), _prefabs.transform.localScale.y, _prefabs.transform.localPosition.z);
    }
    void HandleMovement()
    {
        if (_currentState == PlayerState.MOVE)
        {
            Vector3 direction = _movementInput.normalized;
            transform.position += direction * PlayerMovementSpeed * Time.deltaTime;
        }
    }
}
