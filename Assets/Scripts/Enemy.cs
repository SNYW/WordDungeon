using UnityEngine;

public class Enemy : MonoBehaviour
{
    public int startingHealth;
    public int currentHealth;
    public HealthBar healthBar;

    private void Start()
    {
        currentHealth = startingHealth;
        healthBar.UpdateHealthBar(currentHealth, startingHealth);
    }

    public void Init(int hp)
    {
        startingHealth = hp;
        currentHealth = startingHealth;
        healthBar.UpdateHealthBar(currentHealth, startingHealth);
    }

    public void TakeDamage(int amount)
    {
        currentHealth -= amount;
        if(currentHealth <= 0)
        {
            Die();
        }
        healthBar.UpdateHealthBar(currentHealth, startingHealth);
    }

    private void Die()
    {
        GameManager.gm.SpawnNewEnemy();
        Destroy(gameObject);
    }
}
