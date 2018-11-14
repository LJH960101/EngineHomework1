using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoblinSOMMON : GoblinFSMState
{
    public override void BeginState()
    {
        base.BeginState();
    }

    public override void EndState()
    {
        base.EndState();
    }

    public void Sommon()
    {
        int sommonMany = Random.Range(1, _manager.MyStatData.GoblinSommonMany + 1);
        for (int i = 0; i < sommonMany; ++i)
        {
            var throwableSlime = Instantiate(_manager.Stat.throwableSlime, transform.position + transform.up * 6, Quaternion.identity);
            Vector3 dirVec = transform.forward * Random.Range(500f, 1000f);
            throwableSlime.GetComponent<Rigidbody>().AddForce(dirVec);
        }
    }
}
