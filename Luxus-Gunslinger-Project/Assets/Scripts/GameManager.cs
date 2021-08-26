using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{

    public Text coinText;

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
