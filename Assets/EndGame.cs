using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndGame : MonoBehaviour
{
   
    public void EndTheGame()
    {
        Application.Quit();
    }

    public void RestartTheGame()
    {
        SceneManager.LoadScene(1);
    }
}
