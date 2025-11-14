using UnityEngine;
using UnityEngine.UI;

public class healthbar : MonoBehaviour
{

    [SerializeField] private Image healthBar;

    public void updatehealthbar(float maxHealth, float currentHealth)
    {
        healthBar.fillAmount = currentHealth / maxHealth;
    }
}
