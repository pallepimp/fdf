using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LumberjackHealth : MonoBehaviour {

    int health = 100;
    
    // Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void TakeDamage(int damage)
    {
        GetComponentInChildren<ParticleSystem>().Play();
        health -= damage;
        if (health <= 0)
        {
            Destroy(gameObject);
        }
    }
}
