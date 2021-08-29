using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Enemy : MonoBehaviour
{

    public int maxHealth = 100;
    public int coinPoints = 5;
    int currentHealth;
    public int damage = 20;

    public HealthBar healthbar;
    public GameObject popupCoin;

    // Start is called before the first frame update


    private void OnTriggerEnter2D(Collider2D collision)
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        PlayerHealth player = collision.collider.GetComponent<PlayerHealth>();

        if (player != null)
        {
            player.takeDamage(damage);

        }
    }


    void Start()
    {
        currentHealth = maxHealth;
        healthbar.setMaxHealth(maxHealth);
    }

    public void takeDamage(int damage)
    {
        currentHealth -= damage;
        healthbar.setHealth(currentHealth);
        FindObjectOfType<AudioManager>().playSound("enemyHit");
        if(currentHealth <= 0)
        {
            destroyEnemy();
        }
    }


    void destroyEnemy()
    {
        Instantiate(popupCoin, gameObject.transform.position, gameObject.transform.rotation);
        Destroy(gameObject);
        FindObjectOfType<GameManager>().addAmountToCoins(coinPoints);


    }


}
