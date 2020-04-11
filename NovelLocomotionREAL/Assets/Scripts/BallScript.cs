using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;


public class BallScript : MonoBehaviour
{
    public bool grounded;
    // Start is called before the first frame update
    void Start()
    {
        grounded = true;
        
        Rigidbody ground;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnCollisionEnter(Collision collision)
    {
        //if(collision.rigidbody == ground)
        {

        }
    }


}
