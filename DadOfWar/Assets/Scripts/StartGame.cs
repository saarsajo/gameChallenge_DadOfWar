using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class StartGame : MonoBehaviour
{
    /// <summary>
    /// Starts the game
    /// </summary>
    public void StartTheGame()
    {
        SceneManager.LoadScene("TheWoods");
    }
}
