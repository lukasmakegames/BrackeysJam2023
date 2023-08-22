using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    public Slider slider;
    public GameObject target;  // Assign the target GameObject (player/enemy) in the Inspector

    private void Start()
    {
        if (target != null)
        {
            // Initialize the slider's max value based on the target's initial health
            Health healthComponent = target.GetComponent<Health>();
            if (healthComponent != null)
            {
                slider.maxValue = healthComponent.maxHealth;
                UpdateHealthBar(healthComponent.currentHealth);
            }
        }
    }

    public void UpdateHealthBar(float health)
    {
        // Update the slider's value to reflect the current health
        slider.value = health;
    }
}