using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/**
*a mouse script I was working on, decided to just use my usual one, can work on this again later on 
*
**/

public class FPS_mouseLook : MonoBehaviour {

    public float rotationSpeed = 0.5f;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void FixedUpdate () {

        Vector3 lookVector = (Vector3.up * Input.GetAxis("Mouse X")) + (Vector3.left * Input.GetAxis("Mouse Y"));

        

        transform.Rotate(lookVector * rotationSpeed); //rotate left and right


        Quaternion rot = transform.rotation;
        //rot.x = Mathf.Clamp(rot.eulerAngles.y, -45, 45);
       // rot.z = Mathf.Clamp(rot.eulerAngles.z, 0, 0);
        transform.rotation = rot;


    }
}
