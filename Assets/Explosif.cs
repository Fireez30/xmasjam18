using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explosif : MonoBehaviour
{
    public int radius;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        GameObject[] presents = GameObject.FindGameObjectsWithTag("present");
        foreach(GameObject c in presents)
        {
            if ((c.gameObject.transform.position - gameObject.transform.position).magnitude <= radius)
            {
                Destroy(c);
            }
        }
        StartCoroutine(DestroyWhenPlayed());
    }
    public IEnumerator DestroyWhenPlayed()
    {
        gameObject.GetComponent<AudioSource>().Play();
        yield return new WaitUntil(() => gameObject.GetComponent<AudioSource>().isPlaying == false);
        Destroy(this);
    }

}
