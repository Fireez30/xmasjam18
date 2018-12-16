using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class finJeu : MonoBehaviour
{

    public Text score;
    public Button retry, quit;

    private KeepScore gm;

    // Start is called before the first frame update
    void Start()
    {
        gm = GameObject.FindGameObjectWithTag("scoremem").GetComponent<KeepScore>();
        score.text = "" + gm.score;
        retry.onClick.AddListener(() => reloadGame());
        quit.onClick.AddListener(() => quitGame());
    }
    public void reloadGame()
    {
        SceneManager.LoadScene(1);
    }
    public void quitGame()
    {
        Application.Quit();
    }
}
