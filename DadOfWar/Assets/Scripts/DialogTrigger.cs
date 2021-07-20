using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogTrigger : MonoBehaviour
{

    public Dialog dialog;

    public void TriggerDialog()
    {
        FindObjectOfType<DialogManager>().StartDialog(dialog);
    }


    void OnCollisionEnter2D(Collision2D other)
    {
        if (this.gameObject && other.gameObject.tag == "Player")
        {
            TriggerDialog();
        }
    }

}
