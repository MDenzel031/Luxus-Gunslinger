using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollision : MonoBehaviour
{

    public Animator playerAnimation;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.tag == "DeathObstacle/Spike" || collision.collider.tag == "DeathObstacle/Water")
        {
            disablePlayerMovement();
            playerAnimation.SetBool("isHurt", true);
            Invoke("destroyObject", 1f);
            gameOver();



        }
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
