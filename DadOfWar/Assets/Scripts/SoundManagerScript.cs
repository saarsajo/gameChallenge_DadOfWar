using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Manages the sound effects of the game
/// </summary>
public class SoundManagerScript : MonoBehaviour
{
    public static AudioClip enemydestroyed, enemyhitted, playerhitted, hpCollect, xpCollect, swingAxe;
    static AudioSource audioSource;

    // Start is called before the first frame update
    void Start()
    {
        enemyhitted = Resources.Load<AudioClip>("enemyhitted");
        enemydestroyed = Resources.Load<AudioClip>("enemydestroyed");

        playerhitted = Resources.Load<AudioClip>("playerhitted");
        swingAxe = Resources.Load<AudioClip>("swingAxe");

        hpCollect = Resources.Load<AudioClip>("hpCollect");
        xpCollect = Resources.Load<AudioClip>("xpCollect");

        audioSource = GetComponent<AudioSource>();
    }

    /// <summary>
    /// Defines what audio clip will be played in which case
    /// </summary>
    /// <param name="clip"></param>
    public static void PlaySound (string clip)
    {
        switch (clip)
        {
            case "enemydestroyed":
                audioSource.PlayOneShot(enemydestroyed);
                break;
            case "enemyhitted":
                audioSource.PlayOneShot(enemyhitted);
                break;
            case "playerhitted":
                audioSource.PlayOneShot(playerhitted);
                break;
            case "hpCollect":
                audioSource.PlayOneShot(hpCollect);
                break;
            case "xpCollect":
                audioSource.PlayOneShot(xpCollect);
                break;
            case "swingAxe":
                audioSource.PlayOneShot(swingAxe);
                break;
        }
    }
}
