using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoyDialogueTrigger : MonoBehaviour
{
    public DialogTrigger trigger;

    /// <summary>
    /// When player walks to the boy, dialogue is triggered
    /// </summary>
    /// <param name="other"></param>
    void OnCollisionEnter2D(Collision2D other)
    {
        if (this.gameObject && other.gameObject.tag == "Player")
        {
            trigger.TriggerDialog();
        }
    }
}
