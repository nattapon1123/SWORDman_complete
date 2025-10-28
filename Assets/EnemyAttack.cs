using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    public float damage = 10;
    protected PlayerStats playerStats;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("PlayerStats"))
        {
            playerStats = collision.GetComponent<PlayerStats>();
            playerStats.TakeDamage(damage);

            SpecialAttack();
        }
    }

    public virtual void SpecialAttack()
    {
        // ฟังก์ชันนี้จะถูก override ในคลาสลูก
    }
}
