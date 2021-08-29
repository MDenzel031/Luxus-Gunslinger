using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{

    public Sound[] sound;


    private void Awake()
    {
        foreach(Sound s in sound)
        {
            s.source = gameObject.AddComponent<AudioSource>();
            //s.source.name = s.name;
            s.source.clip = s.clip;
            s.source.volume = s.volume;
            s.source.pitch = s.pitch;
            s.source.loop = s.loop;
        }


    }


    public void playSound(string name)
    {
        Sound isExist = null;
        foreach(Sound s in sound)
        {
            if(s.name == name)
            {
                isExist = s;
            }
        }

        if(isExist != null)
        {
            isExist.source.Play();
        }
        else
        {
            Debug.LogWarning(name + " does not exist");
        }
    }


    public void stopSound(string name)
    {
        Sound isExist = null;
        foreach(Sound s in sound)
        {
            if(s.name == name)
            {
                isExist = s;
            }
        }

        if(isExist != null)
        {
            isExist.source.Stop();
        }
        else
        {
            Debug.LogWarning(name + " does not exist");
        }
    }

    public Sound decreaseSoundVolume(string name)
    {

        Sound isExist = null;
        foreach (Sound s in sound)
        {
            if (s.name == name)
            {
                isExist = s;
            }
        }

        if (isExist != null)
        {
            return isExist;
        }
        else
        {
            return null;
        }
    }


    public Sound getSound(string name)
    {
        Sound result = null;

        foreach(Sound s in sound)
        {
            if (s.name.Equals(name))
            {
                result = s;
            }
        }

        if (result != null) return result;
        else return null;
    }
}
