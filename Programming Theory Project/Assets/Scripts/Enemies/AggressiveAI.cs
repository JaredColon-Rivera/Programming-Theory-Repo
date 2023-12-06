using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Inheritance 
public class AggressiveAI : WanderingAI
{

    private GameObject player;
    private Rigidbody enemyRb;

    private void Start()
    {
        enemyRb = GetComponent<Rigidbody>();
        player = GameObject.Find("Player");
     

    }

    private void Update()
    {
        Movement();
    }

    // Polymorphism
    protected override void Movement()
    {
        if (player != null)
        {
            Vector3 lookDirection = (player.transform.position - transform.position).normalized;
            enemyRb.AddForce(lookDirection * speed);
        }

    }

}
