using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoblinPATROL : GoblinFSMState
{
    public Vector3 destination;

    public override void BeginState()
    {
        base.BeginState();
        destination = new Vector3(Random.Range(-10, 10), 0, Random.Range(-10, 10));
    }

    public override void EndState()
    {
        base.EndState();
    }

    private void Update()
    {
        // 적을 찾았거나, 이미 찾은 상태면 쫒는다
        if (_manager._bOnFound || GameLib.DetectCharacter(_manager.Sight, _manager.PlayerCC))
        {
            _manager._bOnFound = true;
            _manager.SetState(GoblinState.CHASE);
            return;
        }

        if (Vector3.Distance(destination, transform.position) < 0.1f)
        {
            _manager.SetState(GoblinState.IDLE);
            return;
        }

        _manager.CC.CKMove(destination, _manager.Stat);
    }
}