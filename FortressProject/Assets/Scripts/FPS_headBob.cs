using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FPS_headBob : MonoBehaviour
{

    public FPS_Control Controller; //reference to main control
    public float frequency = 2f;
    public float amplitude = 1.0f;
    public float restoreSpeed = 0.5f; //speed to restore to original pos
    public float bobLimit = 0.2f; //limit to stop/start bobbing
    private Vector3 startPos;

    // Use this for initialization
    void Start()
    {
        startPos = transform.localPosition;
        float weight = Controller.getWeight();
       // amplitude *= weight;
        frequency /= weight;

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (Controller.getSpeed() > bobLimit || Controller.getSpeed() < -bobLimit)
        {
            Vector3 _newPosition = transform.localPosition;
            _newPosition.y += (((Mathf.Sin(Time.time * frequency)) * amplitude) * (Controller.getSpeed() / Controller.maxSpeed));
            _newPosition.x += (((Mathf.Sin(Time.time * frequency / 2)) * amplitude) * (Controller.getSpeed() / Controller.maxSpeed));
            transform.localPosition = _newPosition;
        }
        else
        {
            transform.localPosition = Vector3.Lerp(transform.localPosition, startPos, Time.deltaTime * restoreSpeed);

        }

    }
}
