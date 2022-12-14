using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMove : MonoBehaviour
{
    public Rigidbody charRigidbody;
    public float characterSpeed = 4;
    public float leftRightSpeed = 5;
    public float jumpForce = 490f;
    public LayerMask groundMask;
    static public bool move = false;
    static public bool run = true;
    private bool jump;
    Animator anim;

    private void Start()
    {
        anim = GetComponent<Animator>();
    }
    void Update()
    {
        // move character forward when playing the game
        if (run == true)
        {
            transform.Translate(Vector3.forward * Time.deltaTime * characterSpeed, Space.World);

            // set player controls
            if (move == true)
            {
                if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
                {
                    if (this.gameObject.transform.position.x > Boundary.leftSide)
                    {
                        transform.Translate(Vector3.left * Time.deltaTime * leftRightSpeed);
                    }
                }

                if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
                {
                    if (this.gameObject.transform.position.x < Boundary.rightSide)
                    {
                        transform.Translate(Vector3.left * Time.deltaTime * leftRightSpeed * -1);
                    }
                }

                if (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow))
                {
                    Jump();
                }
            }
        }
    }

    // use raycasting to only allow player to jump when on the ground
    void Jump()
    {
        float height = GetComponent<Collider>().bounds.size.y;
        bool isOnGround = Physics.Raycast(transform.position, Vector3.down, (height / 2) + 0.1f, groundMask);
        if (isOnGround) 
        { 
            jump = true;
            anim.SetBool("jump", jump);
            charRigidbody.AddForce(Vector3.up * jumpForce);
        }
    }
}
