using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


//The xp system
public class XpScript : MonoBehaviour
{
    public static int xpValue = 0;
    Text xp;

    void Start()
    {
        xp = GetComponent<Text>();
    }

    // Update the xp value to screen
    void Update()
    {
        xp.text = "Xp: " + xpValue;
    }
}
