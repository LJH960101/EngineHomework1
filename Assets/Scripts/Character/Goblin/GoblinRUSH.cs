using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoblinRUSH : GoblinFSMState
{
    Vector3 moveVector;
    // 캐릭터 충돌 무시 레이어
    const int ignoreLayer = 12;
    int tempLayer;
    float timer;
    public override void BeginState()
    {
        base.BeginState();
        // 이동 벡터를 구함
        moveVector = (_manager.PlayerTransform.position - transform.position).normalized;
        moveVector.y = 0;
        timer = 0f;
        // 충돌을 못하게 바꿈.
        tempLayer = gameObject.layer;
        gameObject.layer = ignoreLayer;
    }

    // 적이 닿았다면 데미지 입히기
    public void OnEnterCharacter(Collider collision)
    {
        CharacterStat targetStat =
            collision.gameObject.GetComponent<CharacterStat>();
        if (targetStat == null) return;

        CharacterStat.ProcessDamage(_manager.Stat, targetStat, (int)(_manager.Stat.Str * _manager.MyStatData.GoblinRushDamageRate));
    }

    public override void EndState()
    {
        base.EndState();
        gameObject.layer = tempLayer;
    }

    // 일정시간 전진 후 돌아옴.
    private void Update()
    {
        transform.position = transform.position + moveVector * _manager.MyStatData.GoblinRushSpeed;
        timer += Time.deltaTime;
        if(timer > _manager.MyStatData.GoblinRushTime)
        {
            _manager.SetState(GoblinState.IDLE);
        }
    }
}