using System.Reflection;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    [Header("Health Settings")]
    public int maxHealth = 100;
    private int currentHealth;
    public Slider healthSlider;

    [Header("Player respawn Settings")]
    [SerializeField] GameObject player;
    [SerializeField] Transform spawnPoint;
    [SerializeField] float spawnValue;

    [Header("UI Settings")]

    [SerializeField] private Image healthBar;
    

    void Start()
    {
        currentHealth = maxHealth;
       
    }


    public void updatehealthbar(float maxHealth, float currentHealth)
    {
        healthBar.fillAmount = currentHealth / maxHealth;
    }
    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        if (currentHealth <= 0)
        {
            currentHealth = 0;
            Die();
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
    }

   
    void Die()
    {
        transform.position = spawnPoint.position;  
        currentHealth = maxHealth; 

        Debug.Log("Player died");
    }
}