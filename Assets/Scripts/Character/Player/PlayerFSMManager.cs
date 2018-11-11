﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum PlayerState
{
    IDLE = 0,
    RUN,
    CHASE,
    ATTACK,
    DEAD
}

[RequireComponent(typeof(PlayerStat))]
[ExecuteInEditMode]
public class PlayerFSMManager : FSMManager
{
    private bool _isinit = false;
    public PlayerState startState = PlayerState.IDLE;
    private Dictionary<PlayerState, FSMState> _states = new Dictionary<PlayerState, FSMState>();

    [SerializeField]
    private PlayerState _currentState;
    public PlayerState CurrentState
    {
        get
        {
            return _currentState;
        }
    }

    public FSMState CurrentStateComponent
    {
        get { return _states[_currentState]; }
    }

    private Transform _marker;
    public Transform Marker
    {
        get
        {
            return _marker;
        }
    }

    private CharacterController _cc;
    public CharacterController CC { get { return _cc; } }

    private PlayerStat _stat;
    public PlayerStat Stat { get { return _stat; } }

    private Transform _target;
    public Transform Target { get { return _target; } }

    private Animator _anim;
    public Animator Anim { get { return _anim; } }

    public CharacterController testTarget;

    public int clickLayer = 0;

    protected override void Awake()
    {
        base.Awake();

        SetGizmoColor(Color.red);
        clickLayer = (1 << 9) + (1 << 10);
        _marker = GameObject.FindGameObjectWithTag("Marker").transform;
        if(null == _marker)
        {
            Debug.LogError("No Marker Assigned!");
            return;
        }

        _cc = GetComponent<CharacterController>();
        _stat = GetComponent<PlayerStat>();
        _anim = GetComponentInChildren<Animator>();

        PlayerState[] stateValues = (PlayerState[])System.Enum.GetValues(typeof(PlayerState));
        foreach (PlayerState s in stateValues)
        {
            System.Type FSMType = System.Type.GetType("Player" + s.ToString());
            FSMState state = (FSMState)GetComponent(FSMType);
            if(null == state)
            {
                state = (FSMState)gameObject.AddComponent(FSMType);
            }

            _states.Add(s, state);
            state.enabled = false;
        }

    }

    private void Start()
    {
        SetState(startState);
        _isinit = true;
    }

    public void SetState(PlayerState newState)
    {
        if(_isinit)
        {
            _states[_currentState].enabled = false;
            _states[_currentState].EndState();
        }
        _currentState = newState;
        _states[_currentState].BeginState();
        _states[_currentState].enabled = true;
        _anim.SetInteger("CurrentState", (int)_currentState);
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray r = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if(Physics.Raycast(r, out hit, 10000.0f, clickLayer))
            {
                if(hit.transform.gameObject.layer == 9)
                {
                    _marker.position = hit.point;
                    _target = null;
                    SetState(PlayerState.RUN);
                    _marker.gameObject.SetActive(true);
                }
                else if(hit.transform.gameObject.layer == 10)
                {
                    _target = hit.transform;
                    SetState(PlayerState.CHASE);
                    _marker.gameObject.SetActive(false);
                }
            }
        }
    }

    public override void NotifyTargetKilled()
    {
        SetState(PlayerState.IDLE);
    }

    public override void SetDeadState()
    {
        SetState(PlayerState.DEAD);
    }
}