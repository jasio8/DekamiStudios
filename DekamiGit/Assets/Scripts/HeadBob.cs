using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeadBob : MonoBehaviour
{
    public float frequency = 1;
    public float magnitude =1;
    float timer;
    public bool Grounded = true;
    float sprintSpeed;

    private Vector3 startpos;

    public Transform CameraHolder;


    private void Awake()
    {
        startpos = CameraHolder.localPosition;
    }

    private void FixedUpdate()
    {
        if(Grounded)
        { 
             timer += Time.deltaTime;
            if(Input.GetKey(KeyCode.LeftShift))
            {
                sprintSpeed = 2f;
            }
            else
            {
                sprintSpeed = 1f;
            }
            float vertical = Input.GetAxisRaw("Vertical");
            CameraHolder.localPosition = Vector3.up * Mathf.Sin(timer * frequency * Mathf.Abs(vertical) * sprintSpeed) * magnitude;
            CameraHolder.localPosition += new Vector3(0,startpos.y,0);
        }

    }


}
