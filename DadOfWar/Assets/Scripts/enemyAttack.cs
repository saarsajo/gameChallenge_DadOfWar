using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

/// <summary>
/// Script to make the enemy walk toward player when player is close to enemy
/// </summary>
public class enemyAttack : MonoBehaviour
{
    public float speed = 3f;
    public Transform Player;
    public float playerEnemyDistance = 7f;

    Rigidbody2D enemyBody;
    public Animator enemyAnimations;

    private void Start()
    {
        enemyBody = GetComponent<Rigidbody2D>();
        try
        {
            enemyAnimations = GetComponent<Animator>();
        }
        catch (Exception exception)
        {
            Debug.Log("You have received error: " + exception.Message + " while loading animator, please code better");
        }
    }

    /// <summary>
    /// Update is called once per frame, 
    /// </summary>
    void Update()
    {
        Vector3 displacement = Player.position - transform.position;
        displacement = displacement.normalized;
        if (Vector2.Distance(Player.position, transform.position) < playerEnemyDistance)
        {
            if(Player.position.x > transform.position.x)
            {
                transform.localScale = new Vector3(-1, 1, 1);
                enemyAnimations.SetBool("EnemyRunning", true);
            }
            else
            {
                transform.localScale = new Vector3(1, 1, 1);
                enemyAnimations.SetBool("EnemyRunning", true);
            }

            transform.position += (displacement * speed * Time.deltaTime);
        }
        else
        {
            enemyAnimations.SetBool("EnemyRunning", false);
        }

    }

}