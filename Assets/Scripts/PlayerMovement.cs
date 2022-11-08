using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class PlayerMovement : MonoBehaviour
{

    Rigidbody playerRigidBody;

    [SerializeField]
    float movementSpeed = 5f;

    [SerializeField]
    float jumpForce = 5f;

    [SerializeField]
    Transform groundCheck;

    [SerializeField]
    LayerMask ground;

    [SerializeField]
    public string textToBeShown;

    // Start is called before the first frame update
    void Start()
    {
        playerRigidBody = GetComponent<Rigidbody>();
    }



    // Update is called once per frame
    void Update()
    {

        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        playerRigidBody.velocity = new Vector3(horizontalInput * movementSpeed, playerRigidBody.velocity.y, verticalInput * movementSpeed);


        if (Input.GetButtonDown("Jump") && IsGrounded())
        {
            playerRigidBody.velocity = new Vector3(playerRigidBody.velocity.x, jumpForce, playerRigidBody.velocity.z);
        }


        //if (Input.GetKeyDown(KeyCode.Space))
        //{
        //    playerRigidBody.velocity = new Vector3(0, 5f, 0);
        //}
        //if (Input.GetKey(KeyCode.UpArrow))
        //{
        //    playerRigidBody.velocity = new Vector3(0, 0, 5f);
        //}
        //if (Input.GetKey(KeyCode.DownArrow))
        //{
        //    playerRigidBody.velocity = new Vector3(0, 0, -5f);
        //}
        //if (Input.GetKey(KeyCode.LeftArrow))
        //{
        //    playerRigidBody.velocity = new Vector3(-5f, 0, 0);
        //}
        //if (Input.GetKey(KeyCode.RightArrow))
        //{
        //    playerRigidBody.velocity = new Vector3(5f, 0, 0);
        //}
    }

    bool IsGrounded()
    {
        return Physics.CheckSphere(groundCheck.position, .1f, ground);
    }
}
