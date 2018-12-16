using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Parameters : MonoBehaviour
{
    public Text scoreText;

    private int score;
    private List<Cheminee> allCheminee;

    // Start is called before the first frame update
    void Awake()
    {
        allCheminee = new List<Cheminee>();
        score = 0;
        scoreText.text = "" + score;
        DontDestroyOnLoad(this.gameObject);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        
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
