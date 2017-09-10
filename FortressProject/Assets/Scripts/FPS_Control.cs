using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/**
* class FPS_Control
*This class handles movement for the FPS player, will take input from
*axis vertical/horizontal, handle jumping, crouching, etc...
**/

public class FPS_Control : MonoBehaviour {

    public float weight = 1.0f; //default weight of 10, weight affects player movement
    public float acceleration = 1.0f; //vertical speed aka, just speed, ignoring horizontal for now
    public float jumpSpeed = 1.0f;
    public float rotationSpeed = 0.5f;
    public bool grounded = false;
    //public float horizontalSpeed = 1.0f; not needed currently, can add if wanted later.
    public float maxSpeed = 10.0f; //THIS IS THE MAX VELOCITY OF THE PLAYER, will stop weird infinite accel effect
    private Rigidbody rb;

    // Use this for initialization
    void Start () {
        rb = GetComponent<Rigidbody>();
        acceleration /= weight;
        jumpSpeed /= weight;
        maxSpeed /= weight;
    }
	
	// Update is called once per frame
	void Update () {

        //MOVEMENT

        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");
        float jumpVertical = 0.0f;

       

        //  Vector3 movement = new Vector3(moveHorizontal, jumpVertical*jumpSpeed, moveVertical);
        Vector3 movement = (transform.forward * moveVertical) + (transform.right * moveHorizontal); //SUM OF all movement vectors, 

  

        if (Input.GetButtonDown("Jump") && grounded)
        {  //add jump force only if pressed down
            jumpVertical = 1;
            Vector3 jump = (transform.up * jumpVertical);
            rb.AddForce(jump * jumpSpeed); //seperate jump from movement, or else jump will not work when moving
        }

        if (rb.velocity.magnitude < maxSpeed && grounded)
        {
            rb.AddForce(movement * acceleration);
           
        }


        //ROTATION

        transform.Rotate(Vector3.up * Input.GetAxis("Mouse X") * rotationSpeed); //rotate left and right

    }

   public float getWeight ()  //get weight, keeping weight protected keeps it from being set randomly
    {

        return weight;

    }

   public void setWeight (float f) //set weight, keeping weight protected keeps it from being set randomly
    {
        weight = f;

    }
    public float getSpeed () //returns speed to other scripts dependent on it
    {

        return rb.velocity.magnitude;

    }

    public void OnCollisionEnter (Collision info)
    {

        grounded = true;

    }
    public void OnCollisionStay(Collision info)
    {

        grounded = true;

    }
    public void OnCollisionExit (Collision info)
    {
        grounded = false;

    }
}
