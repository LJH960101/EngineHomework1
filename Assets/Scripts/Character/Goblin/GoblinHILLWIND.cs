using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoblinHILLWIND : GoblinFSMState
{
    bool _bOnTurnLeft;
    public override void BeginState()
    {
        base.BeginState();
        // 랜덤하게 방향을 정함.
        _bOnTurnLeft = Random.Range(0, 2) == 0 ? true : false;
    }

    public override void EndState()
    {
        base.EndState();
    }
    private void Update()
    {
        // 일정시간동안 돌아줌.
        Vector3 turnVec = Vector3.zero;
        turnVec.y = _manager.MyStatData.GoblinHillWindTurnSpeed;
        if (_bOnTurnLeft) turnVec.y *= -1;
        transform.Rotate(turnVec);
    }
    public override void AttackBehavior()
    {
        base.AttackBehavior();
        // 플레이어의 거리로 피격 판정을 한다.
        if(Vector3.Distance(transform.position, _manager.PlayerTransform.position) <= _manager.MyStatData.GoblinHillWindRange)
        {
            CharacterStat.ProcessDamage(_manager.Stat, _manager.PlayerTransform.gameObject.GetComponent<CharacterStat>(), (int)(_manager.Stat.Str * _manager.MyStatData.GoblinHillWindDamageRate));
        }
    }
}