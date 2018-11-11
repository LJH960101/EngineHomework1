using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(PlayerFSMManager))]
public class FSMState : MonoBehaviour
{
    protected PlayerFSMManager _manager;

    private void Awake()
    {
        _manager = GetComponent<PlayerFSMManager>();    
    }

    public virtual void BeginState()
    {

    }

    public virtual void EndState()
    {

    }

    protected virtual void Update()
    {
        if(GetType().IsDefined(typeof(TargetCheckAttribute), false))
        {
            if(_manager.Target == null)
            {
                _manager.SetState(PlayerState.IDLE);
            }
        }
    }
}
