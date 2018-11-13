using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlimeAnimEvent : MonoBehaviour
{
    SlimeFSMManager _manager;
    SlimeATTACK _attackCp;
    private void Awake()
    {
        _manager = transform.root.GetComponent<SlimeFSMManager>();
        _attackCp = _manager.GetComponent<SlimeATTACK>();
    }

    void HitCheck()
    {
        if (null != _attackCp)
        {
            _attackCp.AttackCheck();
        }
    }
}
