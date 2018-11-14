using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RushBound : MonoBehaviour {
    GoblinFSMManager _manager;
	// Use this for initialization
	void Start () {
        _manager = transform.parent.GetComponent<GoblinFSMManager>();
	}
    // 이 컴포넌트는 오직 러시중에만 처리한다.
    private void OnTriggerEnter(Collider other)
    {
        if(_manager.CurrentState == GoblinState.RUSH)
        {
            _manager.GetComponent<GoblinRUSH>().OnEnterCharacter(other);
        }
    }
}
