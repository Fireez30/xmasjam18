using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Ligne : MonoBehaviour
{

    public List<GameObject> giftType;
    public List<Sprite> giftSprite;
    public float speedRotation, speedForce;
    public GameObject traineau;
    public float thrust;
    public Image spriteNext;

    private GameObject present;
    private int nextPresent;
    private GameObject point1, point2;
    private float distance;
    private LineRenderer line;
    private bool vise;
    private int dir;
    public AudioSource jauge;


    // Start is called before the first frame update
    private void Awake()
    {
        dir = -1;
        point1 = gameObject;
        point2 = gameObject.transform.GetChild(0).gameObject;
        line = gameObject.GetComponent<LineRenderer>();
        distance = -3;
        vise = true;
        traineau = GameObject.FindGameObjectWithTag("traineau");
        setNextPresent();
    }

    // Update is called once per frame
    private void FixedUpdate()
    {
        if (Input.GetButton("startForce") && distance <= -3 && distance >= -10)
        {
            if (!jauge.isPlaying)
            {
                jauge.Play();
            }
            Debug.Log(distance + " " + dir);
            distance += Time.fixedDeltaTime * speedForce * dir;
            if (dir < 0)
                distance = Mathf.Max(-9.999f, distance);
            else
                distance = Mathf.Min(-3.001f, distance);
            if (distance >= -3.001f || distance <= -9.999f)
                dir *= -1;
            traineau.GetComponent<LateralMovement>().moving = false;
            if (present == null)
            {
                present = Instantiate(giftType[nextPresent], point1.transform);
                present.GetComponent<Rigidbody2D>().isKinematic = true;
                setNextPresent();
            }
            point2.transform.localPosition = new Vector3(0, distance, 0);
        }
        else if (!Input.GetButton("startForce") && distance < -3 && distance > -10)
        {

            this.GetComponent<AudioSource>().Play(0);
            Debug.Log("lance cadeau");
            present.transform.parent = null;
            traineau.GetComponent<LateralMovement>().moving = true;
            Vector3 direction = (point2.transform.position - point1.transform.position);
            direction.Normalize();
            present.GetComponent<Rigidbody2D>().isKinematic = false;
            present.GetComponent<Rigidbody2D>().AddForce(new Vector3(-direction.x *distance* thrust, -direction.y*distance* thrust, 0));
            present = null;
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

    private void setNextPresent()
    {
        nextPresent = Random.Range(0, giftType.Count);
        if(nextPresent != giftType.Count-1)
            spriteNext.sprite = giftSprite[nextPresent];
        else
            spriteNext.sprite = giftSprite[Random.Range(0, giftSprite.Count)];
    }
}
