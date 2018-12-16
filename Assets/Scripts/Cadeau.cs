using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cadeau : MonoBehaviour
{
    public int score;

    private List<GameObject> allAdjacent;
    public int idChemine;
    private int multiplier;

    // Start is called before the first frame update
    void Awake()
    {
        idChemine = -1;
        multiplier = 1;
        allAdjacent = new List<GameObject>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.layer == 8) //Si c'est une cheminée
        {
            idChemine = collision.gameObject.GetComponent<Cheminee>().id;
            Debug.Log("collision cheminee");
        }
        if (collision.gameObject.tag == "present" && collision.gameObject.GetComponent<Cadeau>().getCheminee()!=-1) //Si c'est un cadeau qui sera aspiré
        {
            idChemine = collision.gameObject.GetComponent<Cadeau>().getCheminee();
            allAdjacent.Add(collision.gameObject);
            Debug.Log("collision cadeau"+ "idchemine" + idChemine);

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
