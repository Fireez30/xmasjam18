using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Parameters : MonoBehaviour
{
    public Text scoreText;

    private int score;

    // Start is called before the first frame update
    void Awake()
    {
        score = 0;
        scoreText.text = "" + score;
        DontDestroyOnLoad(this.gameObject);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        
    }

    public void addSCore(int s)
    {
        score += s;
        scoreText.text = "" + score;
    }
}
