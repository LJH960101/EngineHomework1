using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum GoblinState
{
    IDLE = 0,
    CHASE,
    BASICATTACK,
    HILLWIND,
    RUSH,
    SOMMON,
    DEAD
}

[RequireComponent(typeof(GoblinStat))]
[ExecuteInEditMode]
public class GoblinFSMManager : FSMManager
{
    private bool _isinit = false;
    public GoblinState startState = GoblinState.IDLE;
    private Dictionary<GoblinState, GoblinFSMState> _states = new Dictionary<GoblinState, GoblinFSMState>();

    [SerializeField]
    private GoblinState _currentState;
    public GoblinState CurrentState
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

    private GoblinStat _stat;
    public GoblinStat Stat { get { return _stat; } }

    private Animator _anim;
    public Animator Anim { get { return _anim; } }

    protected override void Awake()
    {
        base.Awake();

        SetGizmoColor(Color.green);
        _cc = GetComponent<CharacterController>();
        _stat = GetComponent<GoblinStat>();
        _anim = GetComponentInChildren<Animator>();

        _playercc = GameObject.FindGameObjectWithTag("Player").GetComponent<CharacterController>();
        _playerTransform = _playercc.transform;

        GoblinState[] stateValues = (GoblinState[])System.Enum.GetValues(typeof(GoblinState));
        foreach (GoblinState s in stateValues)
        {
            System.Type FSMType = System.Type.GetType("Goblin" + s.ToString());
            GoblinFSMState state = (GoblinFSMState)GetComponent(FSMType);
            if (null == state)
            {
                state = (GoblinFSMState)gameObject.AddComponent(FSMType);
            }

            _states.Add(s, state);
            state.enabled = false;
        }

    }

    public void SetState(GoblinState newState)
    {
        if (_isinit)
        {
            _states[_currentState].enabled = false;
            _states[_currentState].EndState();
        }
        _currentState = newState;
        _states[_currentState].BeginState();
        _states[_currentState].enabled = true;
        _anim.SetBool("OnAttack", false);
        _anim.SetInteger("CurrentState", (int)_currentState);
    }

    private void Start()
    {
        SetState(startState);
        _isinit = true;
    }

    public override void NotifyTargetKilled()
    {
        SetState(GoblinState.IDLE);
    }

    public override void SetDeadState()
    {
        SetState(GoblinState.DEAD);
    }
}
