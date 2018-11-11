using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimEvent : MonoBehaviour
{
    PlayerFSMManager _manager;
    private void Awake()
    {
        _manager = transform.root.GetComponent<PlayerFSMManager>();
    }

    void HitCheck()
    {
        PlayerATTACK attackState = _manager.CurrentStateComponent as PlayerATTACK;
        if(null != attackState)
        {
            attackState.AttackCheck();
        }
        //transform.root.SendMessage("AttackCheck");
    }

}
