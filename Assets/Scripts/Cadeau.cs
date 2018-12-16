using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cadeau : MonoBehaviour
{
    public int score;
    public float rangeHor;

    private List<GameObject> allAdjacent;
    public int idChemine;
    private int multiplier;
    private Parameters gm;

    // Start is called before the first frame update
    void Awake()
    {
        idChemine = -1;
        multiplier = 1;
        allAdjacent = new List<GameObject>();
        gm = GameObject.FindWithTag("GameManager").GetComponent<Parameters>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "present" && collision.gameObject.GetComponent<Cadeau>().getCheminee()!=-1) //Si c'est un cadeau qui sera aspiré
        {
            allAdjacent.Add(collision.gameObject);
        }
        else if (collision.gameObject.layer == 8)
        {
            if (!gameObject.GetComponent<AudioSource>().isPlaying)
            {
                gameObject.GetComponent<AudioSource>().Play();
            }
        }
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        idChemine = -1;
        if (collision.gameObject.layer == 8)
        {
            idChemine = collision.gameObject.GetComponent<Cheminee>().id;

        }
        foreach (GameObject go in allAdjacent)
        {
            int id = go.GetComponent<Cadeau>().getCheminee();
            if (id != -1)
            {
                Vector3 cheminee = gm.getCheminee(id).gameObject.transform.position;
                if(gameObject.transform.position.x > cheminee.x - rangeHor && gameObject.transform.position.x < cheminee.x + rangeHor)
                    idChemine = id;
            }
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "present")
        {
            allAdjacent.Remove(collision.gameObject);
        }
        else if (collision.gameObject.layer == 8)
        {
            idChemine = -1;
        }
    }

    public int getCheminee()
    {
        return idChemine;
    }

    public void setMultiplier(int i)
    {
        multiplier = i;
    }

    public int getScore()
    {
        return score * multiplier;
    }
}
