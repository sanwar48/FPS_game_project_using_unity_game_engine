﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class soldierMovement : MonoBehaviour {

	// Use this for initialization
	[SerializeField]
	Transform _destination;

	NavMeshAgent _navMeshAgent;

	void Start () {

		_navMeshAgent = this.GetComponent <NavMeshAgent> ();

		if (_navMeshAgent == null) {
			Debug.LogError ("The nav mesh agent component is not attached to " + gameObject.name);
		} else {
			SetDestination ();
		}
	}

	// Update is called once per frame
	void Update () {

	}

	private void SetDestination()
	{
		if (_destination != null) {
			Vector3 targetVector = _destination.transform.position;
			_navMeshAgent.SetDestination (targetVector);
		}
	}

}
