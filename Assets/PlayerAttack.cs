using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    public float attackDamage = 0f;
    private int enemyLayer;

    void Start()
    {
        enemyLayer = LayerMask.NameToLayer("Enemy"); // เลเยอร์ของศัตรู
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer == enemyLayer)
        {
            var enemy = collision.GetComponent<Enemy>();
            Debug.Log("โจมตีศัตรู: " + collision.name + " ด้วยดาเมจ " + attackDamage);
            enemy.TakeDamage(attackDamage);
        }
    }
}
