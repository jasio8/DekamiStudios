using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovementScript : MonoBehaviour
{

    Vector2 SR;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
        SR.x = Input.GetAxisRaw("Horizontal");
        SR.y = Input.GetAxisRaw("Vertical");

        this.transform.position = this.transform.position + (new Vector3(SR.x,SR.y,0).normalized * 0.01f);
    }
}
