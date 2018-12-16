using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cheminee : MonoBehaviour
{
    public static int nbInstances = 0;
    public int id;
    private void Awake()
    {
        id = nbInstances ++;
    }

    public void Absorb()
    {
        GameObject[] presents = GameObject.FindGameObjectsWithTag("present");
        Debug.Log("NbCadeau = " + presents.Length + " id cheminee = " + id);
        foreach (GameObject present in presents)
        {
            if (present.GetComponent<Cadeau>().getCheminee() == id)
            {
                //get score
                Destroy(present);
            }
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
