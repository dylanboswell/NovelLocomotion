using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;


public class BallScript : MonoBehaviour
{
    public bool isGrabbed;
    public bool inAir;
    public bool landGood;
    public GameObject ball;
    public Transform ballPosition;
    public Rigidbody ballRigidbody;
    public GameObject xRRig;
    public Transform rigPosition;
    
    public Material working;
    public Material landed;
    public Collider ground;
    public Material groundColor;
    public Material broken;
    // Start is called before the first frame update
    void Start()
    {
        isGrabbed = false;
        inAir = true;
        landGood = true;
       
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("XRI_Left_SecondaryButton") || Input.GetButtonDown("XRI_Right_SecondaryButton"))
        {
            ballPosition.position = rigPosition.position;
        }
        if (Input.GetButtonDown("XRI_Left_PrimaryButton") || Input.GetButtonDown("XRI_Right_PrimaryButton"))
        {
            if (landGood == true)
            {
                rigPosition.position = ballPosition.position;
            }
        }
    }

    public void OnGrab()
    {
        isGrabbed = true;
        ball.GetComponent<MeshRenderer>().material = working;

    }
    public void OnRelease()
    {
        isGrabbed = false;
        inAir = true;
       
    }

    public void OnTriggerEnter(Collider other)
    {
        if (inAir == true)
        {
            Debug.Log("grabbed");
            ball.GetComponent<MeshRenderer>().material = landed;
            if (other == ground)
            {
                ball.GetComponent<MeshRenderer>().material = groundColor;
                
                inAir = false;
                Debug.Log("moved");

            }
            else if(other.tag == "Floor")
            {
                ball.GetComponent<MeshRenderer>().material = groundColor;
                
                landGood = true;
                inAir = false;
                Debug.Log("moved");
            }
            else
            {
                ball.GetComponent<MeshRenderer>().material = broken;
                landGood = false;
                return;
            }
        }
        else
        {
            return;
        }

    }


}
