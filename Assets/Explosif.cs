using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explosif : MonoBehaviour
{
    public int radius;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        GameObject[] presents = GameObject.FindGameObjectsWithTag("presents");
        foreach(GameObject c in presents)
        {
            if ((c.gameObject.transform.position - gameObject.transform.position).magnitude <= radius)
            {
                Destroy(c);
            }
        }
        Destroy(this);
    }
}
