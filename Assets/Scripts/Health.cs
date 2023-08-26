using UnityEngine;
using UnityEngine.SceneManagement;

public class Health : MonoBehaviour
{
    public float maxHealth = 100f;
    public float currentHealth;
    public int score = 50;

    public bool isBoss = false;
    private void Start()
    {
        currentHealth = maxHealth;
    }

    public virtual void TakeDamage(float damageAmount)
    {
        currentHealth -= damageAmount;
        currentHealth = Mathf.Clamp(currentHealth, 0f, maxHealth);

        // Update the health bar UI
        HealthBar healthBar = GetComponentInChildren<HealthBar>();
        if (healthBar != null)
        {
            healthBar.UpdateHealthBar(currentHealth);
        }

        if (currentHealth <= 0f)
        {
            AudioManager.Instance.EnemyDead(transform.position);
            Die();
        }
    }

    private void Die()
    {
        EventAgregator.updateScore.Invoke(score);
        if (isBoss)
        {
            SceneManager.LoadScene("WinScene");
        }
        // Implement death behavior here
        Destroy(gameObject);
    }
}
