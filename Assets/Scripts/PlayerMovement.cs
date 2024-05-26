using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D rb;
    private BoxCollider2D coll;
    private SpriteRenderer sprite;
    private Animator anim;
    [SerializeField] private LayerMask JumpableGround;
    
    private float dirX = 0f;

    [SerializeField] private float moveSpeed = 7f;
    [SerializeField] private float jumpForce = 14f;

    private bool moveLeft;
    private bool moveRight;
    private float horizontalMove;
    
    private enum MovementState { Idle, Running, Jumping, Falling }

    [SerializeField] private AudioSource JumpSoundEffect;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        coll = GetComponent<BoxCollider2D>();
        sprite = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();

        moveLeft = false;
        moveRight = false;
    }

    // Update is called once per frame
    private void Update()
    {
        // Move();
        
        dirX = Input.GetAxisRaw("Horizontal");
        rb.velocity = new Vector2(dirX * moveSpeed, rb.velocity.y);

        if (Input.GetButtonDown("Jump") && IsGrounded())
        {
            JumpSoundEffect.Play();
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
        }
        
        UpdateAnimationState();
    }

    /*public void PointerDownLeft()
    {
        moveLeft = true;
    }

    public void PoiterUpLeft()
    {
        moveLeft = false;
    }

    public void PointerDownRight()
    {
        moveRight = true;
    }

    public void PointerUpRight()
    {
        moveRight = false;
    }
    
    public void Move()
    {
        rb.velocity = new Vector2(horizontalMove, rb.velocity.y);
    }
    
    public void Jump()
    {
        if (IsGrounded())
        {
            JumpSoundEffect.Play();
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
        }
    }*/

    private void UpdateAnimationState()
    {
        MovementState state;

        /*if (moveRight)
        {
            horizontalMove = moveSpeed;
            state = MovementState.Running;
            sprite.flipX = false;
        }
        else if (moveLeft)
        {
            horizontalMove = -moveSpeed;
            state = MovementState.Running;
            sprite.flipX = true;
        }
        else
        {
            horizontalMove = 0;
            state = MovementState.Idle;
        }*/
        
        if (dirX > 0f)
        {
            state = MovementState.Running;
            sprite.flipX = false;
        }
        else if (dirX < 0f)
        {
            state = MovementState.Running;
            sprite.flipX = true;
        }
        else
        {
            state = MovementState.Idle;
        }
        
        if (rb.velocity.y > .1f)
        {
            state = MovementState.Jumping;
        }
        else if (rb.velocity.y < -.1f)
        {
            state = MovementState.Falling;
        }

        anim.SetInteger("state", (int)state);
    }

    private bool IsGrounded()
    {
        return Physics2D.BoxCast(coll.bounds.center, coll.bounds.size, 0f, Vector2.down, .1f, JumpableGround);
    }
}
