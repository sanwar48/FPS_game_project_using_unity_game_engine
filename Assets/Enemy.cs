using UnityEngine;
using System.Collections;

public class Enemy : MonoBehaviour
{
    [SerializeField]
    GameObject player;
    [SerializeField]
    GameObject gun;
    float timer = 0f;

    void Update()
    {
        timer += Time.deltaTime;
        Vector3 heading = gun.transform.position - player.transform.position;
        float distance = heading.magnitude;
        Vector3 direction = heading / distance;
        if (distance < 30f)
        {
            Vector3 newdir = Vector3.RotateTowards(transform.forward, -heading, 10 * Time.deltaTime, 0.0f);
            transform.rotation = Quaternion.LookRotation(newdir);
            RaycastHit hit;
            if (Physics.Raycast(gun.transform.position, -direction, out hit, distance + 20))
            {
                if (timer > 2f)
                {
                    Debug.DrawRay(gun.transform.position, -direction * distance, Color.red, 0.6f);
                    if (hit.transform.gameObject.tag == "Player")
                    {
                        PlayerHealth.instance.Health();
                    }
                    timer = 0f;
                }
            }

        }
    }
}
