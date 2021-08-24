using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Sound
{
    public string name; //NAME OF THE SONG
    public AudioClip clip; //CLIP OF THE SONG

    [HideInInspector]
    public AudioSource source;

    [Range(0f, 1f)]
    public float volume;

    [Range(1f, 3f)]
    public float pitch;

    public bool loop;
}
