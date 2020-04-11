using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;


public class BallScript : MonoBehaviour
{
    public bool isGrabbed;
    public GameObject ball;
    public Transform ballPosition;
    public GameObject xRRig;
    public Transform rigPosition;

    public Rigidbody ground;
    // Start is called before the first frame update
    void Start()
    {
        isGrabbed = false;
        
       
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnCollisionEnter(Collision collision)
    {
        if (isGrabbed == true)
        {
            if (collision.rigidbody == ground)
            {
                rigPosition = ballPosition;
                isGrabbed = false;
            }
            else
            {
                return;
            }
        }
        else
        {
            return;
        }

    }


}
