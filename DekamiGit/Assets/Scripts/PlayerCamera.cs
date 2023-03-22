using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCamera : MonoBehaviour
{
    public float sensX;
    public float sensY;

    public Transform orientation;



    float xRot;
    float yRot;
    void Start()
    {
        Cursor.lockState= CursorLockMode.Locked;
        Cursor.visible= false;
    }

    private void FixedUpdate()
    {

    }

    void Update()
    {
        
        float mouseX = Input.GetAxisRaw("Mouse X") * Time.deltaTime * sensX; 
        float mouseY = Input.GetAxisRaw("Mouse Y") * Time.deltaTime * sensY;

        xRot += mouseX;
        yRot += mouseY;
        yRot = Mathf.Clamp(yRot, -90, 90);

        transform.rotation = Quaternion.Euler(-yRot, xRot, 0);
        orientation.rotation = Quaternion.Euler(0,xRot, 0);
    }


}
