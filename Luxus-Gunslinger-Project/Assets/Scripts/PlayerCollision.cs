using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollision : MonoBehaviour
{

    public Animator playerAnimation;


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.tag == "DeathObstacle/Spike")
        {
            FindObjectOfType<AudioManager>().playSound("enemyHit");
            FindObjectOfType<GameManager>().playerDeath();
        }

        if(collision.collider.tag == "DeathObstacle/Water")
        {
            FindObjectOfType<GameManager>().playerDeath();
            FindObjectOfType<AudioManager>().playSound("waterSplash");
        }
    }



}
