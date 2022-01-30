using UnityEngine;
using System.Collections;

public class Gun : MonoBehaviour {

    public float damage = 10f;
    public float range = 100f;

    //public Camera fpsCam;
    //public GameObject impactEffect;
    //public GameObject pos;
    

	void Update () {
		if (Input.GetButtonDown("Fire1"))
        {
            Shoot();
        }
	}

    void Shoot()
    {
        Debug.DrawRay(transform.position, transform.forward, Color.green, 1f);
        RaycastHit hit;
        if(Physics.Raycast(transform.position, transform.forward,out hit,range))
        {
            Debug.Log(hit.transform.name);
            if (hit.transform.gameObject.tag == "Guard")
            {
                Target target = hit.transform.GetComponent<Target>();
                if (target != null)
                {
                    target.TakeDamage(damage);
                }
            }
            //Instantiate(impactEffect, impactEffect.transform.localPosition, Quaternion.identity);

            //impactEffect.gameObject.SetActive(true);
            //StartCoroutine("Timer");
        }
    }

    //IEnumerator Timer()
    //{
    //    yield return new WaitForSeconds(0.5f);
    //    impactEffect.gameObject.SetActive(false);
    //}
    
}
