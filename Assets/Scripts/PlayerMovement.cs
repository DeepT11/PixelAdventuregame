using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
 private Rigidbody2D rb;
 private SpriteRenderer sprite;
 private Animator anim;
 private BoxCollider2D coll;

 [SerializeField] private LayerMask jumpableGround;

 private float dirX=0f;
 //to make it show at the player movement, used [serialiseffiels]
 //or else we can use public also.
 [SerializeField] private float moveSpeed=7f;
 [SerializeField] private float jumpForce=14f;


 private enum MovementState {idle,running,jumping,falling };

    // Start is called before the first frame update
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        sprite = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();
        coll = GetComponent<BoxCollider2D>();
    }

    // Update is called once per frame
    private void Update()
    {
        //by raw we get 0 immediately
        dirX = Input.GetAxisRaw("Horizontal");
        rb.velocity = new Vector2(dirX * moveSpeed, rb.velocity.y);
        // Debug.Log("Hello world!");
         //this if block will only be done once,so we need to update the jumping in UpdateAnimation
        if (Input.GetButtonDown("Jump") && IsGrounded())
        {
            //Vector 3:data holder for the 3 values
            rb.velocity = new Vector2(rb.velocity.x,jumpForce);
        }

       UpdateAnimation();   
    }

    private void UpdateAnimation()
    {
       MovementState state;

        if(dirX > 0f){
            // anim.SetBool("running",true);
            state = MovementState.running;
            sprite.flipX=false;
        }else if (dirX < 0f){
            // anim.SetBool("running",true);
            state = MovementState.running;
            sprite.flipX=true;
        }else{
            state = MovementState.idle;
            // anim.SetBool("running",false); 
        }

        //when player is in air,dont need to see the jumping or idle pos there
        
        //.1f becoz of precision is like 0.000000...1 ,not exactly 1,so better use .1
        if (rb.velocity.y > .1f){
            state = MovementState.jumping;
        }else if(rb.velocity.y < -.1f){
            state = MovementState.falling;
        }

        anim.SetInteger("state",(int)state);
    }


    //when in an air,no jump
    private bool IsGrounded()
    {
        return Physics2D.BoxCast(coll.bounds.center,coll.bounds.size,0f,Vector2.down,.1f,jumpableGround);

    }
}
