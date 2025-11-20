using UnityEngine;

public class Projectile : MonoBehaviour
{
    public float projectileSpeed;
    public float lifeTime;

    public int damageAmount = 20;



    void Start()
    {
        Invoke("destroyprojectile", lifeTime);
    }

    void FixedUpdate()
    {
        transform.Translate(Vector3.forward * projectileSpeed * Time.deltaTime);
    }

void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player")) 
        {
            PlayerHealth playerHealth = other.GetComponent<PlayerHealth>();
            if (playerHealth != null)
            {
                playerHealth.TakeDamage(damageAmount);
                Debug.Log($"projectile dealt {damageAmount} damage to player");
                destroyprojectile();
            }
        }
    }

    void destroyprojectile()
    {
        Destroy(gameObject);
    }
}
