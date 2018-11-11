using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(GoblinFSMManager))]
public class GoblinFSMState : MonoBehaviour
{
    protected GoblinFSMManager _manager;

    private void Awake()
    {
        _manager = GetComponent<GoblinFSMManager>();
    }

    public virtual void BeginState()
    {

    }

    public virtual void EndState()
    {

    }
}
