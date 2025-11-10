using UnityEngine;

public class icedamige : MonoBehaviour
{
    public int damageAmount = 10;

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player")) 
        {
            PlayerHealth playerHealth = other.GetComponent<PlayerHealth>();
            if (playerHealth != null)
            {
                playerHealth.TakeDamage(damageAmount);
                Debug.Log($"Ice dealt {damageAmount} damage to player");
                Destroy(gameObject); 
            }
        }
        else if (other.CompareTag("Ground"))
        {
            Destroy(gameObject); 
        }
        


    }
}
