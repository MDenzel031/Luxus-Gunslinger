using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{

    public int maxHealth = 100;
    int currentHealth;

    public HealthBar healthbar;
    public Animator playerAnimation;

    void Start()
    {
        currentHealth = maxHealth;
        healthbar.setMaxHealth(maxHealth);
    }

    public void takeDamage(int damage)
    {
        playerAnimation.SetBool("isHurt", true);
        currentHealth -= damage;
        healthbar.setHealth(currentHealth);
        FindObjectOfType<AudioManager>().playSound("enemyHit");

        if (currentHealth <= 0)
        {
            Destroy(gameObject);
            FindObjectOfType<GameManager>().gameOver();
        }

        playerAnimation.SetBool("isHurt", false);
    }


}
