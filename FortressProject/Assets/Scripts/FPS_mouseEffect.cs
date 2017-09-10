using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FPS_mouseEffect : MonoBehaviour {


    public FPS_Control Controller; //reference to main control

    public float speed = 0.5f;

    public float effectSpeed = 0.25f;

    private Quaternion defaultRot;

	// Use this for initialization
	void Start () {
        defaultRot = transform.localRotation;
        float weight = Controller.getWeight();
        effectSpeed *= weight;
        speed /= weight;

        Impact(2);
    }
	
	// Update is called once per frame
	void Update () {



        if (Input.GetAxis("Mouse X") != 0 && Input.GetAxis("Mouse Y") != 0)
        {

            // Vector3 effect = new Vector3(Input.GetAxis("Mouse X") * effectSpeed, Input.GetAxis("Mouse Y") * effectSpeed, 0);
            // Vector3 effect = transform.localEulerAngles;
            // effect.z += Input.GetAxis("Mouse X");


            //  transform.localEulerAngles = Vector3.Lerp(transform.localEulerAngles, effect, Time.deltaTime * speed);

            defaultRot.x = Input.GetAxis("Mouse Y") * effectSpeed;
            defaultRot.y = Input.GetAxis("Mouse X") * effectSpeed;
            defaultRot.z = Input.GetAxis("Mouse X") * effectSpeed;

        }
       
            transform.localRotation = Quaternion.Lerp(transform.localRotation, defaultRot, Time.deltaTime * speed);
        

    }

    void Impact (int mag)
    {


    }
}
