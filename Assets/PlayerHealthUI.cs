using UnityEngine;
using UnityEngine.UI;

public class PlayerHealthUI : MonoBehaviour
{
    public Slider healthBar;
    public PlayerStats playerStats;

    void Start()
    {
        healthBar.maxValue = playerStats.maxHealth;
        healthBar.value = playerStats.health;
    }

    void Update()
    {
        healthBar.value = playerStats.health;
    }
}
