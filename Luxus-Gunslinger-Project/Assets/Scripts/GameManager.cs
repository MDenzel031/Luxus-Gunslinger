using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System;

public class GameManager : MonoBehaviour
{

    public Text coinText;
    public Text livesText;
    public GameObject gameOverPanel;
    public GameObject player;
    private Sound deathSoundSource;
    bool isDeathSoundSourcePlaying = false;
    public GameObject playerDeathAnimation;

    private int currentLives;
    private bool isGameOver = false;

    private void Awake()
    {
        FindObjectOfType<AudioManager>().playSound("bgMusic");
    }

    private void Start()
    {
        deathSoundSource = FindObjectOfType<AudioManager>().getSound("deathSound");
        currentLives = new PreferenceHelper().getLives();
        if(currentLives != null)
        {
            livesText.text = currentLives.ToString();
        }
        else
        {
            livesText.text = "No value";
        }
    }

    private void Update()
    {
        bool isPause = FindObjectOfType<PausedMenu>().isPause;

        if(isPause == true)
        {
            Sound s = FindObjectOfType<AudioManager>().decreaseSoundVolume("bgMusic");
            s.source.volume = 0.2f;
        }
        else
        {
            Sound s = FindObjectOfType<AudioManager>().decreaseSoundVolume("bgMusic");
            s.source.volume = s.volume;
        }


        //AFTER THE SOUND FINISH PLAYING IT WILL RESTART THE LEVEL
        if (isDeathSoundSourcePlaying == true)
        {
            if (!deathSoundSource.source.isPlaying && isGameOver == false)
            {

                FindObjectOfType<GameManager>().restartLevel();
            }
        }
    }

    public void playerDeath()
    {
        //CONTAINS EVERYTHING TO DISABLE THE PLAYERMOVEMNT AND EXECUTE DEATH ANIMATION
        player.GetComponent<BoxCollider2D>().enabled = false;
        player.GetComponent<CircleCollider2D>().enabled = false;
        player.GetComponent<Rigidbody2D>().gravityScale = 0;
        player.GetComponent<PlayerMovement>().enabled = false;
        player.GetComponent<Animator>().SetBool("isHurt", true);
        player.GetComponent<CharacterController2D>().enabled = false;
        FindObjectOfType<AudioManager>().stopSound("bgMusic");
        Instantiate(playerDeathAnimation, player.transform.position, player.transform.rotation);
        player.SetActive(false);
        isDeathSoundSourcePlaying = true;
        deathSoundSource.source.Play();
        reduceLives();

    }


    public void gameOver()
    {
        restartLevel();
    }

    public void restartLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }


    public void quit()
    {

    }


    public void reduceLives()
    {
        int currentLives = PlayerPrefs.GetInt("Lives") - 1;
        if (currentLives != null && currentLives <= 0)
        {
            new PreferenceHelper().saveData(3);
            gameOverPanel.SetActive(true);
            isGameOver = true;

        }
        else
        {
            new PreferenceHelper().saveData(currentLives);
        }
    }











    //COINS FUNCTIONS AND METHODS
    public void addAmountToCoins(int amount)
    {
        int currentCoins = int.Parse(coinText.text) + amount;
        FindObjectOfType<AudioManager>().playSound("coinSound");
        coinText.text = currentCoins.ToString();
    }


    public void addSingleCoin()
    {
        int currentCoins = int.Parse(coinText.text) + 1;
        FindObjectOfType<AudioManager>().playSound("coinSound");
        coinText.text = currentCoins.ToString();
    }




}
