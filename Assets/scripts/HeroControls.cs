using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeroControls : MonoBehaviour
{
	static Animator anim;
	public float speed = 10.0F;
	public float rotationSpeed = 100.0F;
	// Use this for initialization
	void Start()
	{
		anim = GetComponent<Animator>();
	}

	// Update is called once per frame
	void Update()
	{
		float translation = Input.GetAxis("Vertical") * speed;
		float rotation = Input.GetAxis("Horizontal") * rotationSpeed;
		translation *= Time.deltaTime;
		rotation *= Time.deltaTime;
		transform.Translate(0, 0, translation);
		transform.Rotate(0, rotation, 0);
		if (Input.GetMouseButtonDown(0))
		{
			anim.SetTrigger("is.Shoot");
		}
		if (translation != 0)
		{
			anim.SetBool("is.Running", true);
			anim.SetBool("is.Idle", false);
		}
		else
		{
			anim.SetBool("is.Running", false);
			anim.SetBool("is.Idle", true);
		}

	}
}
