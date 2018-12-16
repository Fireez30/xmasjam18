using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayOhohoh : MonoBehaviour
{
    public AudioSource a;
    public int chance;
    // Start is called before the first frame update
    void Awake()
    {
        a = gameObject.GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (!a.isPlaying)
        {
            int de = Random.Range(0, 499) + 1;
            if (de <= chance)
            {
                a.Play();
            }
        }
    }
}
