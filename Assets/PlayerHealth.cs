using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour {

    public static PlayerHealth instance;
    int health;

    private void Start()
    {
        health = 1;
    }

    private void Awake()
    {
        instance = this;
    }

    public void Health()
    {
        health -= 1;
        if(health <= 0)
        {
            //Game Over;
            Debug.Log("game over");
        }
    }
}
