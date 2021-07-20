using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{

    public Slider Slider;
    public Color Low;
    public Color High;
    public Vector3 Offset;

    /// <summary>
    /// Create a heathbar
    /// </summary>
    /// <param name="health"></param>
    /// <param name="maxHealth"></param>
    public void SetHealth(float health, float maxHealth)
    {
        //Only visible when health is not full
        Slider.gameObject.SetActive(health < maxHealth);
        Slider.value = health;
        Slider.maxValue = maxHealth;

        Slider.fillRect.GetComponentInChildren<Image>().color = Color.Lerp(Low, High, Slider.normalizedValue);
    }


    // Changes the position of the healthbar
    void Update()
    {
        Slider.transform.position = Camera.main.WorldToScreenPoint(transform.parent.position + Offset);
    }
}
