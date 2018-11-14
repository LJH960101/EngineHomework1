using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum SlimeState
{
    IDLE = 0,
    PATROL,
    CHASE,
    ATTACK,
    DEAD
}

[RequireComponent(typeof(SlimeStat))]
[ExecuteInEditMode]
public class SlimeFSMManager : FSMManager
{
    private bool _isinit = false;
    public SlimeState startState = SlimeState.IDLE;
    private Dictionary<SlimeState, SlimeFSMState> _states = new Dictionary<SlimeState, SlimeFSMState>();

    [SerializeField]
    private SlimeState _currentState;
    public SlimeState CurrentState
    {
        get
        {
            return _currentState;
        }
    }

    private CharacterController _cc;
    public CharacterController CC { get { return _cc; } }

    private CharacterController _playercc;
    public CharacterController PlayerCC { get { return _playercc; } }

    private Transform _playerTransform;
    public Transform PlayerTransform { get { return _playerTransform; } }

    private SlimeStat _stat;
    public SlimeStat Stat { get { return _stat; } }

    private Animator _anim;
    public Animator Anim { get { return _anim; } }

    protected override void Awake()
    {
        base.Awake();

        SetGizmoColor(Color.blue);
        _cc = GetComponent<CharacterController>();
        _stat = GetComponent<SlimeStat>();
        _anim = GetComponentInChildren<Animator>();

        _playercc = GameObject.FindGameObjectWithTag("Player").GetComponent<CharacterController>();
        _playerTransform = _playercc.transform;

        SlimeState[] stateValues = (SlimeState[])System.Enum.GetValues(typeof(SlimeState));
        foreach (SlimeState s in stateValues)
        {
            System.Type FSMType = System.Type.GetType("Slime" + s.ToString());
            SlimeFSMState state = (SlimeFSMState)GetComponent(FSMType);
            if (null == state)
            {
                state = (SlimeFSMState)gameObject.AddComponent(FSMType);
            }

            _states.Add(s, state);
            state.enabled = false;
        }

    }

    public void SetState(SlimeState newState)
    {
        if (_isinit)
        {
            _states[_currentState].enabled = false;
            _states[_currentState].EndState();
        }
        _currentState = newState;
        _states[_currentState].BeginState();
        _states[_currentState].enabled = true;
        _anim.SetInteger("CurrentState", (int)_currentState);
    }

    private void Start()
    {
        SetState(startState);
        _isinit = true;
    }

    public override void NotifyTargetKilled()
    {
        SetState(SlimeState.IDLE);
    }

    public override void SetDeadState()
    {
        SetState(SlimeState.DEAD);
    }

    public override bool IsDie() { return CurrentState == SlimeState.DEAD; }
}
