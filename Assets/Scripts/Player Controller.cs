using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Transform orientation;
    public Rigidbody rb;
    public CharacterController controller;
    public Vector3 playerVelocity;
    public bool isGrounded;
    public bool groundPlay;
    public float jumpForce = 1.0f;
    public float playerSpeed = 5.0f;
    public float gravityValue = -9.8f;
    public float jumpHeight = 1;
    //public float jumpCooldown;
    public float verticalMovement;
    public float horizontalMovement;




    // Start is called before the first frame update
    void Start()
    {
        controller = gameObject.GetComponent<CharacterController>();
        rb.freezeRotation = true;
        rb.GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {

        //Player Movement Code
        Vector3 move = new Vector3(Input.GetAxisRaw("Horizontal"), 0, Input.GetAxisRaw("Vertical"));
        controller.Move(move * Time.deltaTime * playerSpeed);

        playerVelocity.y += gravityValue * Time.deltaTime;
        controller.Move(playerVelocity * Time.deltaTime);

        groundPlay = controller.isGrounded;
        if (groundPlay && playerVelocity.y <= 0)
        {
            playerVelocity.y = 0f;
        }

        if (move != Vector3.zero)
        {
            gameObject.transform.forward = move;
        }
        //Player facing
        playerVelocity = orientation.forward * verticalMovement + orientation.right * horizontalMovement;

        //Jump Code
        if (Input.GetButtonDown("Jump") && groundPlay)
        {
            playerVelocity.y = Mathf.Sqrt(jumpHeight * -3.0f * gravityValue);
        }


    }//end Update

}//end class
