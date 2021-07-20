using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

/// <summary>
/// Script to make enemy take damage
/// </summary>
public class enemyHealth : MonoBehaviour
{
    public float HitPoints;
    public float MaxHitPoints = 5;
    public HealthBar healthBar;
    public GameObject bloodEffect;
    public int xpFromKill;

    // Start is called before the first frame update
    void Start()
    {
        HitPoints = MaxHitPoints;
        healthBar.SetHealth(HitPoints, MaxHitPoints);
    }

    /// <summary>
    /// Damage to enemy and if enemy HitPoints are 0 destroy the enemy character
    /// </summary>
    /// <param name="damage"></param>
    /// <param name="hitDirection"></param>
    public void getDamage(float damage, float hitDirection)
    {
        Console.WriteLine("Enemy damaged");
        SoundManagerScript.PlaySound("enemyhitted");
        HitPoints -= damage;
        healthBar.SetHealth(HitPoints, MaxHitPoints);
        gameObject.transform.position = new Vector3(gameObject.transform.position.x + hitDirection, gameObject.transform.position.y, 0);

        //Enemy dies
        if (this.HitPoints <= 0)
        {
            XpScript.xpValue += xpFromKill;
            SoundManagerScript.PlaySound("enemydestroyed");
            Destroy(gameObject);
        }
    } 
}
