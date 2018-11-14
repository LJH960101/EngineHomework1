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
    // 몽둥이 공격 이벤트
    void AttackEvent()
    {
        _manager.AttackBehavior();
    }
    // 몽둥이 공격 종료 이벤트
    void AttackEnd()
    {
        _manager.SetState(GoblinState.IDLE);
    }
    // 소환 이벤트
    void Sommon()
    {
        _sommonCp.Sommon();
    }
}
