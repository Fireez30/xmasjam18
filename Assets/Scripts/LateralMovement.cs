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
    // Update is called once per frame

    private void Awake()
    {
        dir = new Vector3(1, 0, 0);
        isAller = true;
    }

    private void FixedUpdate()
    {
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

        Debug.Log(dir);
        gameObject.transform.position += dir * Time.fixedDeltaTime * speed;
    }

}
