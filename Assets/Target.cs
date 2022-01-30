using UnityEngine;
using UnityEngine.UI;


public class Target : MonoBehaviour {

    public float health = 50f;

    [Header("Unity stuff")]
    public Image healthBar;

    public void TakeDamage (float amount)
    {
        health -= amount;
        //healthBar.fillAmount = health/100f ;
        if (health <= 0f)
        {
            Die();
        }
    }


    void Die()
    {
        Destroy(gameObject);
    }
}
