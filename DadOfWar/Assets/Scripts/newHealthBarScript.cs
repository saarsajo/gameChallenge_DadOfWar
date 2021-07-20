using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class newHealthBarScript : MonoBehaviour
{
    private Image HealthBar;
    public float CurrentHealth;
    private float MaxHealth = 10f;
    playerHealth PlayerHealth;



    // Start is called before the first frame update
    void Start()
    {
        HealthBar = GetComponent<Image>();
        PlayerHealth = FindObjectOfType<playerHealth>();
    }

    // Update is called once per frame
    void Update()
    {
        CurrentHealth = PlayerHealth.HitPoints;
        HealthBar.fillAmount = CurrentHealth / MaxHealth;
    }
}
