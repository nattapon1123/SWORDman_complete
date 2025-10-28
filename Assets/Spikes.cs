using UnityEngine;

public class Spikes : MonoBehaviour
{
    public float damage = 20f;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("PlayerStats"))
        {
            collision.GetComponent<PlayerStats>().TakeDamage(damage);
            Debug.Log("Player hit by spikes, damage: " + damage);
        }
    }
}
