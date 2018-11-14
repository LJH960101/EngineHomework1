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
    public float PlayerStr = 10f;

    public float SlimeMaxHp = 20f;
    public float SlimeAttackRange = 50f;
    public float SlimeMoveSpeed = 50f;
    public float SlimeStr = 10f;

    public float GoblinMaxHp = 20f;
    public float GoblinAttackRange = 50f;
    public float GoblinMoveSpeed = 50f;
    public float GoblinStr = 10f;
    public float GoblinHillWindDamageRate = 2f;
    public float GoblinHillWindRange = 10f;
    public float GoblinRushDamageRate = 3f;
    public float GoblinRushDistance = 10f;
    public int GoblinSommonMany = 5;
    public float GoblinSkillRate = 0.1f;
}
