using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Parameters : MonoBehaviour
{
    public Text scoreText;

    private int score;
    private List<Cheminee> allCheminee;
    public AudioSource timer;
    public float timeLeft;
    public Text timetext;
    public bool played;
    public AudioSource zic;

    // Start is called before the first frame update
    void Awake()
    {
        allCheminee = new List<Cheminee>();
        score = 0;
        scoreText.text = "" + score;
        DontDestroyOnLoad(this.gameObject);
        timeLeft = 120f;
        played = false;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        timeLeft -= Time.fixedDeltaTime;
        if (timeLeft % 60 < 10)
        {
            timetext.text = ((int)(timeLeft / 60f)) + ":0" + ((int)timeLeft % 60) + "";
        }
        else
        {
            timetext.text = ((int)(timeLeft / 60f)) + ":" + ((int)timeLeft % 60) + "";
        }

        if (timeLeft < 0f)
        {
            Time.timeScale = 0;
            if (!played)
            {
                zic.Stop();
                timer.Play();
                played = true;
            }
        }
    }

    public void addCheminee(Cheminee c)
    {
        allCheminee.Add(c);
    }

    public void addSCore(int s)
    {
        score += s;
        scoreText.text = "" + score;
    }

    public Cheminee getCheminee(int id)
    {
        return allCheminee[id];
    }
}
