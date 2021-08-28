using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelComplete : MonoBehaviour
{

    AudioSource source = null;
    bool isPlaying = false;
    public GameObject completeUI;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.collider.tag == "Player")
        {
            collision.collider.gameObject.SetActive(false);
            FindObjectOfType<AudioManager>().stopSound("bgMusic");
            source.Play();
            isPlaying = true;

        }
    }

    private void Start()
    {
        Sound s = FindObjectOfType<AudioManager>().getSound("levelReached");
        source = s.source;
    }

    private void Update()
    {
        if (isPlaying == true)
        {
            if (!source.isPlaying)
            {
                completeUI.SetActive(true);

            }
        }
    }
}
