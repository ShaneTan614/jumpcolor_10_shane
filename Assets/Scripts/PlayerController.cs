using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    
    float jumpForce = 10.0f;
    int Jumpcount = 0;
    float gravityModifier = 2.0f;
    

    Rigidbody playerRb;
    Renderer playerRbr;

    public Material[] playerMters;

    // Start is called before the first frame update
    void Start()
    {
        
        Physics.gravity *= gravityModifier;
        playerRb = GetComponent<Rigidbody>();
        playerRbr = GetComponent<Renderer>();
       
    }

    // Update is called once per frame
    void Update()
    {
        PlayerJump();
    }
    private void OncollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag("ground"))
        {
            Jumpcount = 0;
            playerRbr.material.color = playerMters[1].color;
        }
    }
    private void PlayerJump()
    {
        if(Input.GetKeyDown(KeyCode.Space) && Jumpcount < 5)
        {
            playerRb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            Jumpcount++;
            playerRbr.material.color = playerMters[0].color;
        }
    }
}
