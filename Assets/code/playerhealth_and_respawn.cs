using System.Reflection;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    [Header("Health Settings")]
    public int maxHealth = 100;
    private int currentHealth;

    [SerializeField] private healthbar healthBar;
    

    [Header("Player respawn Settings")]
    [SerializeField] GameObject player;
    [SerializeField] Transform spawnPoint;
    [SerializeField] float spawnValue;

    

    void Start()
    {
        currentHealth = maxHealth;
       
       healthBar.updatehealthbar(maxHealth, currentHealth);
    }

    public void TakeDamage(int damage)
    {
    
        currentHealth -= damage;
        if (currentHealth <= 0)
        {
            currentHealth = 0;
            Die();
        }
        else
        {
            healthBar.updatehealthbar(maxHealth, currentHealth);
        }

    }

     void Update()
    {
        if(player.transform.position.y < -spawnValue)
        {
            currentHealth = 0;
            Die();
        }
    }

    public void Heal(int amount)
    {
        currentHealth += amount;
        if (currentHealth > maxHealth)
        {
            currentHealth = maxHealth;
        }
        
        healthBar.updatehealthbar(maxHealth, currentHealth);
        
    }

   
    void Die()
    {
        transform.position = spawnPoint.position;  
        currentHealth = maxHealth; 
        healthBar.updatehealthbar(maxHealth, currentHealth);
        Debug.Log("Player died");
    }
}