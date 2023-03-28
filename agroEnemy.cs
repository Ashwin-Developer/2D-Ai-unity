using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyAi : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField]
    Transform Player;

    [SerializeField]
    float agroRange;

    [SerializeField]
    float movementSpeed;

    Rigidbody2D rb;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();   
    }

    // Update is called once per frame
    void Update()
    {
        //distance from the player
        float distToPlayer = Vector2.Distance(transform.position, Player.position);
        print("distToPlayer" + distToPlayer);

        if (distToPlayer < agroRange)
        {
            //To chase the player
            chasePlayer();
        }

        else
        {
            //To stop the chase
            stopChasingPlayer();
        }
    }

    void stopChasingPlayer()
    {
        if (transform.position.x < Player.position.x)
        {
            //move the player to right coz enemy is left
            rb.velocity = new Vector2(movementSpeed, 0);
        }

        else if (transform.position.x > Player.position.x)
        {
            //move the player to left coz enemy is right
            rb.velocity = new Vector2(-movementSpeed, 0);
        }
    }

    void chasePlayer()
    {
        if (transform.position.x < Player.position.x)
        {
            //move the player to right coz enemy is left
            rb.velocity = new Vector2(-movementSpeed, 0);
        }

        else if (transform.position.x > Player.position.x)
        {
            //move the player to left coz enemy is right
            rb.velocity = new Vector2(movementSpeed, 0);
        }
    }
}
