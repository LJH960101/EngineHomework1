using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoblinBASICATTACK : GoblinFSMState
{
    public override void BeginState()
    {
        base.BeginState();
    }

    public override void EndState()
    {
        base.EndState();
    }

    public override void AttackBehavior()
    {
        base.AttackBehavior();
        GameLib.SimpleDamageProcess(transform, _manager.Stat.AttackRange,
            "Player", _manager.Stat);
    }
}