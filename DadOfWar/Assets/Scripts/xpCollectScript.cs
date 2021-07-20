using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class xpCollectScript : MonoBehaviour
{

    /// <summary>
    /// When player collects Xp Play sound and add xp
    /// </summary>
    /// <param name="other"></param>
    void OnCollisionEnter2D(Collision2D other)
    {
        if (this.gameObject && other.gameObject.tag == "Player")
        {
            SoundManagerScript.PlaySound("xpCollect");
            XpScript.xpValue += 50;
            Destroy(gameObject);
        }
    }
}
