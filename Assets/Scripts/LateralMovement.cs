using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LateralMovement : MonoBehaviour
{
    public Vector3 startPoint;
    public Vector3 endPoint;
    public float speed;
    public Vector3 dir;
    public bool isAller;
    public bool moving;
    public AudioSource a;
    public Parameters gm;
    public float time;
    public bool done90;
    public bool done60;
    public bool done30;
    // Update is called once per frame

    private void Awake()
    {
        dir = new Vector3(1, 0, 0);
        isAller = true;
        moving = true;
        a = gameObject.GetComponent<AudioSource>();
        gm = GameObject.FindWithTag("GameManager").GetComponent<Parameters>();
        done90 = false;
        done60 = false;
        done30 = false;
    }

    private void FixedUpdate()
    {
        time = gm.timeLeft;
        if(gameObject.transform.position.x > endPoint.x - 0.1 && isAller)
        {
            isAller = false;
            dir = new Vector3(-1, 0, 0);
        }
        else if (gameObject.transform.position.x < startPoint.x + 0.1 && !isAller)
        {
            isAller = true;
            dir = new Vector3(1, 0, 0);
        }

        // Debug.Log(dir);
        if (moving)
        {
            gameObject.transform.position += dir * Time.fixedDeltaTime * speed;
            if (!a.isPlaying)
            {
                a.Play(0);
            }

        }
        else
        {
            if (a.isPlaying)
            {
                a.Stop();
            }
        }

        if (time < 30 && !done30)
        {
            done30 = true;
            speed += 0.5f;
        }
        else if (time < 60 && !done60)
        {
            done60 = true;
            speed += 0.5f;
        }
        else if (time < 90 && !done90)
        {
            done90 = true;
            speed += 0.5f;
        }
    }

}
