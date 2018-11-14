using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoblinIDLE : GoblinFSMState
{
    private float idleTime = 1.0f;
    private float time = 0.0f;

    public override void BeginState()
    {
        base.BeginState();

        // 적당히 랜덤으로 아이들타임을 진행시킨채로 초기화.
        time = Random.Range(0.0f, 0.5f);
    }

    public override void EndState()
    {
        base.EndState();
    }

    private void Update()
    {

        time += Time.deltaTime;
        if (time > idleTime)
        {
            // 일정시간이 지나면 다음 상태로 전이
            if (_manager._bOnFound || GameLib.DetectCharacter(_manager.Sight, _manager.PlayerCC))
            {
                _manager._bOnFound = true;
                _manager.SetState(GoblinState.CHASE);
                return;
            }
            else _manager.SetState(GoblinState.PATROL);
        }
    }
}
