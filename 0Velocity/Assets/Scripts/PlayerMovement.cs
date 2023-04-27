using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private float horizontal;
    private float speed = 8f;
    private float jumpingPower = 16f;

    private float coyoteTime = 0.2f;
    private float coyoteTimeCounter;

    private float jumpBuffer = 0.2f;
    private float jumpBufferCounter;

    [SerializeField] Rigidbody2D rb;
    [SerializeField] CircleCollider2D pos;
    [SerializeField] LayerMask groundLayer;

    // Update is called once per frame
    private void Update()
    {
        horizontal = Input.GetAxisRaw("Horizontal");

        if(IsGrounded())
        {
            coyoteTimeCounter = coyoteTime;
        } else
        {
            coyoteTimeCounter -= Time.deltaTime;
        }

        if(Input.GetButtonDown("Jump"))
        {
            jumpBufferCounter = jumpBuffer;
        }
        else
        {
            jumpBufferCounter -= Time.deltaTime;
        }

        if(coyoteTimeCounter>0f&&jumpBufferCounter>0f)
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpingPower);
            jumpBufferCounter = 0f;
        }

        if(Input.GetButtonUp("Jump") && rb.velocity.y>0f)
        {
            rb.velocity = new Vector2(rb.velocity.x, rb.velocity.y * 0.5f);
            coyoteTimeCounter = 0f;
        }
    }

    private void FixedUpdate()
    {
        rb.velocity = new Vector2(horizontal * speed, rb.velocity.y);
    }

    private bool IsGrounded()
    {
        return Physics2D.CircleCast(pos.bounds.center, pos.radius-0.1f, Vector2.down, 0.2f, groundLayer);
    }
}
