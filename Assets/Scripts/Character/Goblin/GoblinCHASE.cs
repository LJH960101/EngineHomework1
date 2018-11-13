using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoblinCHASE : GoblinFSMState
{
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
            _manager.SetState(GoblinState.IDLE);
            return;
        }

        if (Vector3.Distance(_manager.PlayerTransform.position, transform.position) < _manager.Stat.AttackRange)
        {
            int randPattern = Random.Range(0, 100);
            // 스킬 발동 확률에 들었는가?
            if (randPattern <= (int)(_manager.MyStatData.GoblinSkillRate * 100f))
            {
                // 랜덤한 패턴으로 지정
                randPattern = Random.Range((int)GoblinState.HILLWIND, (int)GoblinState.SOMMON+1);
                switch ((GoblinState)randPattern) {
                    case GoblinState.HILLWIND:
                        _manager.SetState(GoblinState.HILLWIND);
                        break;
                    case GoblinState.RUSH:
                        _manager.SetState(GoblinState.RUSH);
                        break;
                    case GoblinState.SOMMON:
                        _manager.SetState(GoblinState.SOMMON);
                        break;
                    default:
                        Debug.Log("Unexpected Pattern Result");
                        break;
                }
            }
            else
                _manager.SetState(GoblinState.BASICATTACK);

            return;
        }

        _manager.CC.CKMove(_manager.PlayerTransform.position, _manager.Stat);
    }
}
