using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlimeStat : CharacterStat
{
    protected override void Awake()
    {
        base.Awake();
        _maxHp = statData.SlimeMaxHp;
        _hp = _maxHp;
        _attackRange = statData.SlimeAttackRange;
        _moveSpeed = statData.SlimeMoveSpeed;
        _power = statData.SlimePower;
    }
}
