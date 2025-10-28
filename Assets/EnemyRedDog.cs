using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyRedDog : Enemy
{
    private bool knockBack = false;
    public Transform groundCheck;
    public Transform wallCheck;
    public LayerMask layerMask;

    private bool isGrounded;
    private bool isWalled;

    public float speed = 1f;
    private int Direction = -1;
    public float  radius = 0.1f;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    [System.Obsolete]
    private void FixedUpdate()
    {
    Flip();

    if (knockBack) return;

    rb.velocity = new Vector2(Direction * speed, rb.velocity.y);
    }



private void Flip()
{
    isGrounded = Physics2D.OverlapCircle(groundCheck.position, radius, layerMask);         
        isWalled = Physics2D.OverlapCircle(wallCheck.position, radius, layerMask);

        if (!isGrounded || isWalled)
        {
            Direction *= -1;
            transform.localScale = new Vector3(-transform.localScale.x, 1, 1);
        }
}


    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(groundCheck.position, radius);
        Gizmos.DrawWireSphere(wallCheck.position, radius);
    }

    [System.Obsolete]
    public IEnumerator KnockBack(float forceX, float forceY, float duration, Transform otherObject)
{
    int knockBackDirection;

    if (transform.position.x < otherObject.position.x)
        knockBackDirection = -1;
    else
        knockBackDirection = 1;

    knockBack = true;
    rb.velocity = Vector2.zero;

    Vector2 theForce = new Vector2(forceX * knockBackDirection, forceY);
    rb.AddForce(theForce, ForceMode2D.Impulse);

    yield return new WaitForSeconds(duration);

    knockBack = false;
    rb.velocity = Vector2.zero;
}

}
