using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

/// <summary>
///Simple script to move the player character
/// </summary>
public class playerMove : MonoBehaviour
{
    Rigidbody2D body;

    private float horizontal;
    private float vertical;
    public int playerDirection =1;

    public float speed;
    public Animator playerAnimations;
    public playerAttack playerAttack;

    void Start()
    {
        body = GetComponent<Rigidbody2D>();
        try
        {
            playerAnimations = GetComponent<Animator>();
        }
        catch (Exception exception)
        {
            Debug.Log("You have received error: " + exception.Message + " while loading animator, please code better");
        }
    }


    /// <summary>
    /// Update is called every frame. Wait for key inputs to move
    /// </summary>
    void Update()
    {
        if (playerAttack.attacking == false) { 
            horizontal = Input.GetAxisRaw("Horizontal");
            vertical = Input.GetAxisRaw("Vertical");

            //Flip the player sprite if player changes direction
            //Walk right
            if (Input.GetKey(KeyCode.D))
            {

                transform.localScale = new Vector3(1, 1, 1);
                playerDirection = 1;
    }
            //Walk left
            if (Input.GetKey(KeyCode.A))
            {
                transform.localScale = new Vector3(-1, 1, 1);
                playerDirection = 0;
            }

            //Start animation if velocity is not 0
            if (body.velocity.x != 0 || body.velocity.y != 0)
            {
                playerAnimations.SetBool("PlayerRunning", true);
            }
            else
            {
                playerAnimations.SetBool("PlayerRunning", false);
            }
        }
    }

    /// <summary>
    /// Move the player character
    /// </summary>
    private void FixedUpdate()
    {
        body.velocity = new Vector2(horizontal * speed, vertical * speed);
    }

    /// <summary>
    /// This will be the code for player dashing TODO
    /// </summary>
    private void playerDash()
    {

    }
}
