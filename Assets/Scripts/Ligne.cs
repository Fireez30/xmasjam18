using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ligne : MonoBehaviour
{

    public List<GameObject> giftType;
    public float speedRotation, speedForce;

    private GameObject point1, point2;
    private float distance;
    private LineRenderer line;
    private bool vise;

    // Start is called before the first frame update
    private void Awake()
    {
        point1 = gameObject;
        point2 = gameObject.transform.GetChild(0).gameObject;
        line = gameObject.GetComponent<LineRenderer>();
        distance = -3;
        vise = true;
    }

    // Update is called once per frame
    private void FixedUpdate()
    {
        if (Input.GetButton("startForce") && distance > -10)
        {
            distance -= Time.fixedDeltaTime * speedForce;
            point2.transform.localPosition = new Vector3(0, distance, 0);
        }
        else if (!Input.GetButton("startForce") && distance < -3)
        {
            Debug.Log("lance cadeau");
            distance = -3;
            point2.transform.localPosition = new Vector3(0, distance, 0);
        }
        else if(!Input.GetButton("startForce"))
        {
            if (point1.transform.rotation.z < -0.3826834)
                speedRotation *= -1;
            else if (point1.transform.rotation.z > 0.3826834)
                speedRotation *= -1;
            point1.transform.Rotate(new Vector3(0, 0, 1) * Time.fixedDeltaTime * speedRotation);
        }
        line.SetPosition(0, point1.transform.position);
        line.SetPosition(1, point2.transform.position);
    }
}
