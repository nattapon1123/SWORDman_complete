using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float health = 50f; // พลังชีวิตของศัตรู

    protected Rigidbody2D rb;
    protected Animator animator;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    } 

    // ฟังก์ชันให้ศัตรูโดนโจมตี
    public void TakeDamage(float damage)
    {
        health -= damage; // ลดพลังชีวิต

        if (health <= 0)
        {
            Die();
        }
    }

    // ฟังก์ชันตาย
    private void Die()
    {
        // คุณสามารถเพิ่มอนิเมชันตายก่อน Destroy ได้
        Destroy(gameObject);
    }
}
