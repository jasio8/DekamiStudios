using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using UnityEngine;
using UnityEditor;
public class PlayerMovementScript : MonoBehaviour
{
    public Transform orientation;
    public float groundDrag;
    Rigidbody rb;
    Vector3 MoveDirection;
    float horizontalInput;
    float verticalInput;


    [Header("Movement")]
    public float speedMultiplier = 10f;


    [Header("Ground Check")]
    public float playerHeight;
    public LayerMask whatIsGround;
    bool grounded;









    
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.freezeRotation= true;
    }

    void Update()
    {
        grounded = Physics.Raycast(transform.position, Vector3.down,playerHeight *0.5f + 0.2f, whatIsGround);

        MyInput();

        if(grounded)
        {
            rb.drag = groundDrag;
        }
        else
        {
            rb.drag = 0;
        }
    }

    void FixedUpdate()
    {
        MovePlayer();
    }


    void MyInput()
    {
      horizontalInput = Input.GetAxisRaw("Horizontal");
      verticalInput = Input.GetAxisRaw("Vertical");
    }

    void MovePlayer()
    {
        MoveDirection = orientation.forward * verticalInput + orientation.right * horizontalInput;
        if (Input.GetKey(KeyCode.LeftShift))
        {
            rb.AddForce(MoveDirection.normalized * speedMultiplier * 20f);
        }
        else
        {
            rb.AddForce(MoveDirection.normalized * speedMultiplier * 10f);
        }

    }
}
