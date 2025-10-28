using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class PlayerStats : MonoBehaviour
{
    public float maxHealth = 100f;
    public float health;

    public Slider healthBar;

    private bool canTakeDamage = true;

    void Start()
    {
        health = maxHealth;

        if (healthBar != null)
        {
            healthBar.minValue = 0f;
            healthBar.maxValue = 1f;
            healthBar.value = health / maxHealth;
        }
    }

    public void TakeDamage(float damage)
    {
        if (!canTakeDamage) return;

        health -= damage;

        if (healthBar != null)
        {
            healthBar.value = health / maxHealth;
        }

        if (health <= 0)
        {
            GetComponent<PolygonCollider2D>().enabled = false;

            GetComponentInParent<GatherInput>().DisableControls();

            Debug.Log("Player is dead");

            if (GameManager.instance != null)
            {
                GameManager.instance.GameOver();
            }
        }

        StartCoroutine(DamagePrevention());
    }

    private IEnumerator DamagePrevention()
    {
        canTakeDamage = false;
        yield return new WaitForSeconds(0.15f);
        if (health > 0)
        {
            canTakeDamage = true;
        }
    }
}
