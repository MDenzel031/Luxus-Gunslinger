using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverScript : MonoBehaviour
{

    
    public void slideToScene()
    {
        int index = SceneManager.GetActiveScene().buildIndex;
        if(index == 0)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
        else
        {
            SceneManager.LoadScene(0);

        }
    }




    public void gameOverMusic()
    {
        FindObjectOfType<AudioManager>().playSound("gameOverMusic");
    }

    public void stopGameOverMusic()
    {
        FindObjectOfType<AudioManager>().stopSound("gameOverMusic");

    }
}
