using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;


public class BallScript : MonoBehaviour
{
    public bool isGrabbed;
    public GameObject ball;
    public Transform ballPosition;
    public Rigidbody ballRigidbody;
    public GameObject xRRig;
    public Transform rigPosition;
    public Transform rigCamera;
    public Material working;
    public Material landed;
    public Collision ground;
    public Material groundColor;
    public Material broken;
    // Start is called before the first frame update
    void Start()
    {
        isGrabbed = false;
        
       
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
       // ballRigidbody.isKinematic = false;
       // ballRigidbody.useGravity = true;
    }

    public void OnCollisionEnter(Collision other)
    {
        if (isGrabbed == true)
        {
            Debug.Log("grabbed");
            ball.GetComponent<MeshRenderer>().material = landed;
            if (other == ground)
            {
                ball.GetComponent<MeshRenderer>().material = groundColor;
                rigPosition.position = ballPosition.position;
                rigCamera = ballPosition;
                isGrabbed = false;
                Debug.Log("moved");

            }
            else
            {
                ball.GetComponent<MeshRenderer>().material = broken;
                return;
            }
        }
        else
        {
            return;
        }

    }


}
