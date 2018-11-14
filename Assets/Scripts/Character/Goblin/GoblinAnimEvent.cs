using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoblinAnimEvent : MonoBehaviour
{
    GoblinFSMManager _manager;
    GoblinSOMMON _sommonCp;
    private void Awake()
    {
        _manager = transform.root.GetComponent<GoblinFSMManager>();
        _sommonCp = _manager.GetComponent<GoblinSOMMON>();
    }
    void AttackEvent()
    {
        _manager.AttackBehavior();
    }
    void AttackEnd()
    {
        _manager.SetState(GoblinState.IDLE);
    }
    void Sommon()
    {
        _sommonCp.Sommon();
    }
}
