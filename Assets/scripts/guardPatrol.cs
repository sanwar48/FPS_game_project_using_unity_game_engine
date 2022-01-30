using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class guardPatrol : MonoBehaviour {
	[SerializeField]
	bool _patrolWaiting;
	[SerializeField]
	float _totalWaitTime = 3.0f;
	[SerializeField]
	float _switchProbability = .2f;
	[SerializeField]
	List<WayPoint> _patrolPoints;

	NavMeshAgent _navMeshAgent;
	int _currentPatrolIndex;
	bool _travelling;
	bool _waiting;
	bool _patrolForward;
	float _waitTimer;


	public void Start () {
		_navMeshAgent = this.GetComponent<NavMeshAgent>();
		if(_navMeshAgent == null)
		{
			Debug.LogError("The nav mesh agent is not attatched to" + gameObject.name);

		}
		else
		{
			if(_patrolPoints!=null && _patrolPoints.Count >= 2)
			{
				_currentPatrolIndex = 0;
				//setDestination();
			}
			else
			{
				Debug.Log("Insufficient patrol for basic patrol behavior.");
			}
		}

	}


	public void Update () {
		if(_travelling && _navMeshAgent.remainingDistance <= 1.0f)
		{
			_travelling = false;
			if (_patrolWaiting)
			{
				_waiting = true;
				_waitTimer = 0f;
			}
			else
			{
				changePatrolPoint();
				setDestination();
			}
		}
		if (_waiting)
		{
			_waitTimer += Time.deltaTime;
			if(_waitTimer>= _totalWaitTime)
			{
				_waiting = false;
				changePatrolPoint();
				setDestination();

			}
		}

	}
	private void setDestination()
	{
		if (_patrolPoints != null)
		{
			Vector3 targetvector = _patrolPoints[_currentPatrolIndex].transform.position;
			_navMeshAgent.SetDestination(targetvector);
			_travelling = true;
		}
	}
	private void changePatrolPoint()
	{
		if(UnityEngine.Random.Range(0f, 1f) <= _switchProbability)
		{
			_patrolForward = !_patrolForward;

		}
		if (_patrolForward)
		{
			_currentPatrolIndex = (_currentPatrolIndex + 1) % _patrolPoints.Count;
		}
		else
		{
			if(--_currentPatrolIndex < 0)
			{
				_currentPatrolIndex = _patrolPoints.Count - 1;
			}
		}
	}
}
