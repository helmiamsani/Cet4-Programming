using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SavePositionWithoutCheckPoint : MonoBehaviour {

    // Position of player of current position
    public Vector3 playerCurrentPosition;

    public PlayerManager player;

    public LinearDelayHealth.DelayHealth health;

	// Use this for initialization
	void Start ()
    {
        // Assign player manager script
        player = GetComponent<PlayerManager>();

        // Assign delay health script
        health = GetComponent<LinearDelayHealth.DelayHealth>();
	}
	
	// Update is called once per frame
	void Update ()
    {
        // If our player health is less than or equal to 0
       if(health.curHealth <= 0)
        {
            // Storing the player current position into this position 
            transform.position = playerCurrentPosition;
            
            // Player health is equal to full health
            health.curHealth = health.maxHealth;
        }     
	}


}
