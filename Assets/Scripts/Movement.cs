using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    private Rigidbody2D myRigidbody;
    private CircleCollider2D myFeet;
    private Animator animator;

    private LayerMask ground;

    public int facing = 1;

    private float speed = 5f;
    private float horizontalMovement = 0f;
    private float jumpForce = 7f;

    // Start is called before the first frame update
    void Start()
    {
        myRigidbody = GetComponent<Rigidbody2D>();
        myFeet = GetComponent<CircleCollider2D>();
        animator = GetComponent<Animator>();
        ground = LayerMask.GetMask("Ground");
    }

    // Update is called once per frame
    void Update()
    {
        horizontalMovement = Input.GetAxis("Horizontal");
        if (Input.GetButtonDown("Jump") && myFeet.IsTouchingLayers(ground))
        {
            myRigidbody.AddForce(new Vector2(0f, jumpForce), ForceMode2D.Impulse);
        }
        if (myFeet.IsTouchingLayers(ground)) {
            animator.SetBool("isTouchingGround", true);
        } 
        else
        {
            animator.SetBool("isTouchingGround", false);
        }
    }
    private void FixedUpdate()
    {
        myRigidbody.velocity = new Vector2(horizontalMovement * speed, myRigidbody.velocity.y);
        animator.SetFloat("speed", Mathf.Abs(horizontalMovement));
    }
}
