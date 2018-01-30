using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    [HideInInspector] public bool facingRight = true;
    [HideInInspector] public bool jump = false;
    public float moveForce = 365f;
    public float maxSpeed = 5f;
    public float jumpForce = .005f;
    public float ForwardJump = 1f;

    private int DynamicJumpFrames = 0;
    private int DynamicJumpFramesStart = 6;

    public Transform groundCheck;

   
    private bool grounded = false;
    private Animator anim;
    private Rigidbody2D rb2d;


    // Use this for initialization
    void Awake()
    {
       // anim = GetComponent<Animator>();
        rb2d = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        grounded = Math.Abs(rb2d.velocity.y) < 0.1; //;Physics2D.Linecast(transform.position, groundCheck.position, 1 << LayerMask.NameToLayer("Ground"));

        if (Input.GetButton("Jump") && grounded)
        {
            jump = true;
            DynamicJumpFrames = DynamicJumpFramesStart;
        } else if(!Input.GetButton("Jump"))
        {
            jump = false;
        }
    }

    void FixedUpdate()
    {
        
        float h = Input.GetAxis("Horizontal");
        if (Math.Abs(h) < 0.04) h = 0;
        //anim.SetFloat("Speed", Mathf.Abs(h));
        float curMaxSpeed = (grounded ? maxSpeed : ForwardJump * maxSpeed);

        if (h * rb2d.velocity.x < curMaxSpeed)
            rb2d.AddForce(Vector2.right * h * moveForce);

        if (Mathf.Abs(rb2d.velocity.x) > curMaxSpeed)
            rb2d.velocity = new Vector2(Mathf.Sign(rb2d.velocity.x) * curMaxSpeed, rb2d.velocity.y);

        if (h > 0 && !facingRight)
            Flip();
        else if (h < 0 && facingRight)
            Flip();

        if (jump && DynamicJumpFrames > 0) {
            //  anim.SetTrigger("Jump");
            if(DynamicJumpFrames == DynamicJumpFramesStart) {
                rb2d.AddForce((Vector2.up * jumpForce / 2));
            } else {
                rb2d.AddForce(Vector2.up * ((jumpForce - (jumpForce / 2)) / DynamicJumpFramesStart));
            }
        }

        DynamicJumpFrames = Math.Max(0, DynamicJumpFrames - 1);
    }


    void Flip()
    {
        facingRight = !facingRight;
        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
    }
}
