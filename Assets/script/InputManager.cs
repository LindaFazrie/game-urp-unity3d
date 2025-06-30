using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour
{
    // Start is called before the first frame update
    public Action<Vector2> PlayerMovement;
    public Action JumpAksi;
    
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Movement();
        Jump();
       
        
    }

    private void Movement()
    {
        float Horizontal = Input.GetAxis("Horizontal");
        float Vertical = Input.GetAxis("Vertical");

        if (PlayerMovement != null)
        {
            PlayerMovement(new Vector2(Horizontal, Vertical));
        }
    }

    private void Jump()
    {
        bool OnJump = Input.GetKey(KeyCode.Space);

        if (OnJump)
        {
            if(JumpAksi != null) JumpAksi();
        
        }
    }
}
