using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class playerHealth : MonoBehaviour
{
    public float HitPoints;
    public float MaxHitPoints = 5;
    public HealthBar healthBar;
    public float knockback;

    /// <summary>
    /// Start is called before the first frame update
    /// </summary>
    void Start()
    {
        HitPoints = MaxHitPoints;
        healthBar.SetHealth(HitPoints, MaxHitPoints);
    }

    /// <summary>
    /// When enemy hits player, player takes damage
    /// </summary>
    /// <param name="other"></param>
    void OnCollisionEnter2D(Collision2D other)
    {
        if (this.gameObject && other.gameObject.tag == "Enemy")
        {
            getDamage(1);
        }

        if (this.gameObject && other.gameObject.tag == "hp")
        {
            getHp(2);
            Destroy(other.gameObject);
        }
    }

    /// <summary>
    /// The player damage handler
    /// </summary>
    /// <param name="damage"></param>
    public void getDamage(float damage)
    {
        SoundManagerScript.PlaySound("playerhitted");
        HitPoints -= damage;
        healthBar.SetHealth(HitPoints, MaxHitPoints);
        gameObject.transform.position = new Vector3(gameObject.transform.position.x - knockback, gameObject.transform.position.y, 0);

        if (HitPoints == 0)
        {
            ReloadTheGame();
        }
    }

    public void getHp(float hp)
    {
        SoundManagerScript.PlaySound("hpCollect");
        if (HitPoints < MaxHitPoints)
        HitPoints += hp;
        healthBar.SetHealth(HitPoints, MaxHitPoints);

        if (HitPoints >= MaxHitPoints)
        {
            HitPoints = MaxHitPoints;
        }

    }

    /// <summary>
    /// If player dies Loadmenu is loaded
    /// </summary>
    public void ReloadTheGame()
    {
        XpScript.xpValue = 0;
        SceneManager.LoadScene("Menu");
    }

}
