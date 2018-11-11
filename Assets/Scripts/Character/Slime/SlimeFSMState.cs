using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SlimeFSMManager))]
public class SlimeFSMState : MonoBehaviour
{
    protected SlimeFSMManager _manager;

    private void Awake()
    {
        _manager = GetComponent<SlimeFSMManager>();
    }

    public virtual void BeginState()
    {

    }

    public virtual void EndState()
    {

    }
}
