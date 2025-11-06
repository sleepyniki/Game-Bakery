using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    public int maxHealth = 100;
    private int currentHealth;
    public Slider healthSlider;
    [SerializeField] GameObject player;
    [SerializeField] Transform spawnPoint;

    void Start()
    {
        currentHealth = maxHealth;
        UpdateHealthUI();
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        if (currentHealth <= 0)
        {
            currentHealth = 0;
            Die();
        }
        UpdateHealthUI();
    }

    public void Heal(int amount)
    {
        currentHealth += amount;
        if (currentHealth > maxHealth)
        {
            currentHealth = maxHealth;
        }
        UpdateHealthUI();
    }

    void UpdateHealthUI()
    {
        if (healthSlider != null)
        {
            healthSlider.value = currentHealth;
        }
    }

    void Die()
    {
        // Handle player death (e.g., reload scene, show game over screen)
        transform.position = spawnPoint.position;
        Debug.Log("Player died");
    }
}