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
    public bool IsEnabled;

    [Header("Movement")]
    public float speedMultiplier = 10f;
    public float JumpMultiplier = 10f;

    [Header("Ground Check")]
    public float playerHeight;
    public LayerMask whatIsGround;
    bool grounded;
    public HeadBob bob;








    
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.freezeRotation= true;
    }

    void Update()
    {
    if(IsEnabled)
    { 
        grounded = Physics.Raycast(transform.position, Vector3.down, playerHeight * 0.5f + 0.2f, whatIsGround);

        MyInput();
        bob.Grounded = grounded;
        if (grounded)
        {
            rb.drag = groundDrag;
        }
        else
        {
            rb.drag = groundDrag / 7;
        }
    }
    }

    void FixedUpdate()
    {
        if(grounded)
        {
            MovePlayer(1);
        }
        else
        {
            MovePlayer(0.2f);
        }
        Jump();

    }


    void MyInput()
    {
      horizontalInput = Input.GetAxisRaw("Horizontal");
      verticalInput = Input.GetAxisRaw("Vertical");
    }

    void MovePlayer(float S)
    {
        MoveDirection = orientation.forward * verticalInput + orientation.right * horizontalInput;
        if (Input.GetKey(KeyCode.LeftShift))
        {
            rb.AddForce(MoveDirection.normalized * speedMultiplier * 20f * S);
        }
        else
        {
            rb.AddForce(MoveDirection.normalized * speedMultiplier * 10f * S);
        }


    }


    void Jump()
    {
        if(grounded&&Input.GetKey(KeyCode.Space))
        {

            rb.AddForce(Vector3.up * JumpMultiplier,ForceMode.Impulse);
        }
        
    }

    
}
