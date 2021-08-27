using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollision : MonoBehaviour
{

    public Animator playerAnimation;


    private Sound source;
    bool isPlaying = false;

    private void Start()
    {
        source = FindObjectOfType<AudioManager>().getSound("deathSound");
    }

    private void Update()
    {
        if(isPlaying == true)
        {
            if (!source.source.isPlaying)
            {

                gameOver();
                
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.tag == "DeathObstacle/Spike" || collision.collider.tag == "DeathObstacle/Water")
        {
            playerDeath();
        }
    }

    public void playerDeath()
    {
        disablePlayerMovement();
        playerAnimation.SetBool("isHurt", true);
        FindObjectOfType<AudioManager>().stopSound("bgMusic");
        source.source.Play();
        isPlaying = true;

    }



    private void gameOver()
    {
        FindObjectOfType<GameManager>().restartLevel();
    }

    private void destroyObject()
    {
        Destroy(gameObject);
    }

    private void disablePlayerMovement()
    {
        gameObject.GetComponent<Rigidbody2D>().gravityScale = 0;
        FindObjectOfType<PlayerMovement>().enabled = false;

    }
}
