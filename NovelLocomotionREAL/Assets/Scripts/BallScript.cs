using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;


public class BallScript : MonoBehaviour
{
    public bool isGrabbed;
    public bool inAir;
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
        
       
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnGrab()
    {
        isGrabbed = true;
        ball.GetComponent<MeshRenderer>().material = working;
       // ballRigidbody.isKinematic = true;
       // ballRigidbody.useGravity = false;
    }
    public void OnRelease()
    {
        isGrabbed = false;
        inAir = true;
       // ballRigidbody.isKinematic = false;
       // ballRigidbody.useGravity = true;
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
                rigPosition.position = ballPosition.position;
                
                inAir = false;
                Debug.Log("moved");

            }
            else if(other.tag == "Floor")
            {
                ball.GetComponent<MeshRenderer>().material = groundColor;
                rigPosition.position = ballPosition.position;

                inAir = false;
                Debug.Log("moved");
            }
            else
            {
                ball.GetComponent<MeshRenderer>().material = broken;
                //inAir = false;
                return;
            }
        }
        else
        {
            return;
        }

    }


}
