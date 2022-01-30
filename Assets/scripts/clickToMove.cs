using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class clickToMove : MonoBehaviour {
	private Animator mAnimator;
	private NavMeshAgent mNavMeshAgent;
	private bool mrunning = false;


	// Use this for initialization
	void Start () {
		mAnimator = GetComponent<Animator>();
		mNavMeshAgent = GetComponent<NavMeshAgent>();


	}

	// Update is called once per frame
	void Update () {
		Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
		RaycastHit hit;
		if (Input.GetMouseButtonDown(1))
		{
			if(Physics.Raycast(ray,out hit,100))
			{
				mNavMeshAgent.destination = hit.point;
			}
		}
		if (mNavMeshAgent.remainingDistance <= mNavMeshAgent.stoppingDistance)
		{
			mrunning = false;
		}
		else
		{
			mrunning = true;
		}
		mAnimator.SetBool("running", mrunning);
	}
}
