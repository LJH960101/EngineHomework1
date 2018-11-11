using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerATTACK : MonoBehaviour
{
    PlayerFSMManager _manager;
    private void Awake()
    {
        _manager = GetComponent<PlayerFSMManager>();
    }
    public void AttackCheck()
    {
        var hitObjects = Physics.BoxCastAll(transform.position, transform.lossyScale / 2,
            _manager.MyStatData.PlayerAttackRange * transform.forward);
        foreach(var hitObject in hitObjects)
        {
            if (hitObject.collider.gameObject.tag == "Monster")
            {
                CharacterStat targetStat =
                    hitObject.collider.GetComponent<CharacterStat>();

                CharacterStat.ProcessDamage(_manager.Stat, targetStat);
            }
        }
    }
}
