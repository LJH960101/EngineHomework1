using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlimeCHASE : SlimeFSMState {

    public override void BeginState()
    {
        base.BeginState();
    }

    public override void EndState()
    {
        base.EndState();
    }

    private void Update()
    {
        if (!GameLib.DetectCharacter(_manager.Sight, _manager.PlayerCC))
        {
            _manager.SetState(SlimeState.IDLE);
            return;
        }

        if (Vector3.Distance(_manager.PlayerTransform.position, transform.position) < _manager.Stat.AttackRange)
        {
            _manager.SetState(SlimeState.ATTACK);
            return;
        }

        _manager.CC.CKMove(_manager.PlayerTransform.position, _manager.Stat);
    }
}
