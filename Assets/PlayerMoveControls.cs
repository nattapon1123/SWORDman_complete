using System;
using System.Collections;   // <-- เพิ่มตรงนี้
using UnityEngine;


public class PlayerMoveControls : MonoBehaviour
{
    public float speed = 5f;
    private int direction = 1;
    public float jumpForce = 5f;
    private bool isGrounded = false; 
    private int jumpCount = 0;
    public int maxJumps = 2;
    public bool knockBackActive = false;


    private GatherInput gatherInput;
    private new Rigidbody2D rigidbody2D;
    private Animator animator;

    public Transform groundCheck;
    public float groundCheckRadius = 0.2f;
    public LayerMask groundLayer;

    void Start()
    {
        gatherInput = GetComponent<GatherInput>();
        rigidbody2D = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    [System.Obsolete]
    void Update()
    {
        CheckGround();
        SetAnimatorValues();
        Flip();
        ApplyHorizontalMovement();
        JumpPlayer();
    }

    [System.Obsolete]
    private void ApplyHorizontalMovement()
    {
        float moveInput = gatherInput.valueX;
        Vector2 velocity = rigidbody2D.velocity;

        bool hitWallRight = false;
        bool hitWallLeft = false;

        if (moveInput > 0)
        {
            RaycastHit2D hitRight = Physics2D.Raycast(transform.position, Vector2.right, 0.6f, groundLayer);
            if (hitRight.collider != null)
                hitWallRight = true;
        }

        if (moveInput < 0)
        {
            RaycastHit2D hitLeft = Physics2D.Raycast(transform.position, Vector2.left, 0.6f, groundLayer);
            if (hitLeft.collider != null)
                hitWallLeft = true;
        }

        if (!isGrounded && (hitWallRight || hitWallLeft))
        {
            velocity.x = 0;
        }
        else
        {
            velocity.x = moveInput * speed;
        }

        rigidbody2D.velocity = new Vector2(velocity.x, velocity.y);
    }

    [System.Obsolete]
    private void SetAnimatorValues()
    {
        animator.SetFloat("speed", Mathf.Abs(rigidbody2D.velocity.x));
        animator.SetFloat("vSpeed", rigidbody2D.velocity.y);
        animator.SetBool("grornd", isGrounded);
    }

    private void CheckGround()
    {
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, groundLayer);

        if (isGrounded)
        {
            jumpCount = 0;
        }
    }

    [System.Obsolete]
    private void JumpPlayer()
    {
        if (gatherInput.jumpInput)
        {
            if (jumpCount < maxJumps)
            {
                rigidbody2D.velocity = new Vector2(rigidbody2D.velocity.x, jumpForce);
                jumpCount++;
            }
            gatherInput.jumpInput = false;
        }
    }

    [System.Obsolete]
    private void Flip()
    {
        if (gatherInput.valueX * direction < 0)
        {
            transform.localScale = new Vector3(-transform.localScale.x, 1, 1);
            direction *= -1;
        }
    }

    public IEnumerator KnockBack(float forceX, float forceY, float duration, Transform otherObject)
    {
    int knockBackDirection;

    if (transform.position.x < otherObject.position.x)
        knockBackDirection = -1;
    else
        knockBackDirection = 1;

    knockBackActive = true;
    rigidbody2D.linearVelocity = Vector2.zero;

    Vector2 theForce = new Vector2(forceX * knockBackDirection, forceY);
    rigidbody2D.AddForce(theForce, ForceMode2D.Impulse);

    yield return new WaitForSeconds(duration);

    knockBackActive = false;
    rigidbody2D.linearVelocity = Vector2.zero;
    }
}
