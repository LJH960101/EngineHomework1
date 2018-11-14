using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoblinStat : CharacterStat
{
    public GameObject throwableSlime;
    protected override void Awake()
    {
        base.Awake();
        _maxHp = statData.GoblinMaxHp;
        _hp = _maxHp;
        _attackRange = statData.GoblinAttackRange;
        _moveSpeed = statData.GoblinMoveSpeed;
        _str = statData.GoblinStr;
    }
}
