using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PreferenceHelper
{
    
    public void saveData(int lives)
    {
        PlayerPrefs.SetInt("Lives", lives);
    }

    public void loadData()
    {

    }

    public void deleteData()
    {
        PlayerPrefs.DeleteKey("Lives");
    }

    public int getLives()
    {
        int lives = PlayerPrefs.GetInt("Lives");
        return lives;
    }






}
