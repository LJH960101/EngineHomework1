using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StatData : ScriptableObject
{
    public float AutoDestroyTime = 3f;
    public float TurnSpeed = 540f;

    public float PlayerMaxHp = 100f;
    public float PlayerAttackRange = 50f;
    public float PlayerMoveSpeed = 50f;
    public float PlayerPower = 10f;

    public float SlimeMaxHp = 20f;
    public float SlimeAttackRange = 50f;
    public float SlimeMoveSpeed = 50f;
    public float SlimePower = 10f;

    public float GoblinMaxHp = 20f;
    public float GoblinAttackRange = 50f;
    public float GoblinMoveSpeed = 50f;
    public float GoblinPower = 10f;
    public float GoblinHillWindDamageRate = 2f;
    public float GoblinRushDamageRate = 3f;
}
