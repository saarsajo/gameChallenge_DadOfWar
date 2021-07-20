using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class playerAttack : MonoBehaviour
{
    public float attackRate = 2f;
    float nextAttackTime = 0f;

    public Transform attackPos;
    public float attackRange;
    public LayerMask whatIsEnemies;
    public int damage;
    public int hitDirection = 5;
    public Animator playerAnimations;

    public bool attacking = false;
    public int playerDir;

    /// <summary>
    /// Try to get the Player animation 
    /// </summary>
    private void Start()
    {
        try {
            playerAnimations = GetComponent<Animator>();
        }
        catch (Exception exception)
        {
            Debug.Log("You have received error: " + exception.Message + " while loading animator, please code better");
        }
        
    }

    /// <summary>
    /// Check for player space presses to call attack
    /// </summary>
    void Update()
    {
        playerDir = GetComponent<playerMove>().playerDirection;

        if (Time.time >= nextAttackTime){

            if (Input.GetKeyDown(KeyCode.Space))
            {
                attacking = true;
                hitWithAxe();
                nextAttackTime = Time.time + 1f / attackRange;
            }

        }
        else
        {
            attacking = false;
        }

    }

    /// <summary>
    /// Player hits with an axe
    /// Check the direction of axe hit and time between attack also damage enemy if hit 
    /// </summary>
    void hitWithAxe()
    {
        //Trigger the player attack animation
        playerAnimations.SetTrigger("PlayerAttack");
        SoundManagerScript.PlaySound("swingAxe");

        StartCoroutine(waiter());

        Collider2D[] enemiesToDamage = Physics2D.OverlapCircleAll(attackPos.position, attackRange, whatIsEnemies);
        for (int i = 0; i<enemiesToDamage.Length; i++)
        {
            //Player facing right
            if (playerDir ==1) {
                enemiesToDamage[i].GetComponent<enemyHealth>().getDamage(damage, hitDirection);
}
            //Player facing left
            else
            {
                enemiesToDamage[i].GetComponent<enemyHealth>().getDamage(damage, hitDirection* (-1));
            }
        }
    }

    //Add a delay to checking weather or not the axe hit the enemy, to make it go smoother with the animation
    IEnumerator waiter()
    {
        yield return new WaitForSecondsRealtime(1);
    }


        /// <summary>
        /// Create a red circle to help to see where the player attack hitbox is 
        /// </summary>
        void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawSphere(attackPos.position, attackRange);
    }

}
