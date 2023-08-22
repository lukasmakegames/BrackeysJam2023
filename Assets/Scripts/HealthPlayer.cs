using UnityEngine;

public class HealthPlayer : Health
{
    private Player _player;

    private void Start()
    {
        _player = GetComponent<Player>();
        currentHealth = maxHealth;
        _player.SetStartHP(currentHealth);
    }

    public override void TakeDamage(float damageAmount)
    {
        currentHealth -= damageAmount;
        currentHealth = Mathf.Clamp(currentHealth, 0f, maxHealth);

        EventAgregator.playerLostHP.Invoke(damageAmount);
        // Update the health bar UI
        HealthBar healthBar = GetComponentInChildren<HealthBar>();
        if (healthBar != null)
        {
            healthBar.UpdateHealthBar(currentHealth);
        }

        if (currentHealth <= 0f)
        {
            Die();
        }
    }

    private void Die()
    {
        // Implement death behavior here
        Destroy(gameObject);
    }
}
