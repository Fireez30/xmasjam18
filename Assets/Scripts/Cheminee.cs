using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cheminee : MonoBehaviour
{
    public static int nbInstances = 0;
    public int id;
    public int multiplier;

    private Parameters gm;

    private void Start()
    {
        id = nbInstances ++;
        gm = GameObject.FindGameObjectWithTag("GameManager").GetComponent <Parameters>();
        gm.addCheminee(this);
    }

    public void Absorb()
    {
        GameObject[] presents = GameObject.FindGameObjectsWithTag("present");
        Debug.Log("NbCadeau = " + presents.Length + " id cheminee = " + id);
        int score=0;
        foreach (GameObject present in presents)
        {
            Cadeau c = present.GetComponent<Cadeau>();
            if ( c.getCheminee() == id)
            {
                score += c.getScore();
                Destroy(present);
            }
        }
        gm.addSCore(score);
        if (!gameObject.GetComponent<AudioSource>().isPlaying)
        {
            gameObject.GetComponent<AudioSource>().Play();
        }
    }

    private void FixedUpdate()
    {
        if (Input.GetButton("clear"))
        {
            Absorb();
        }
    }
}
