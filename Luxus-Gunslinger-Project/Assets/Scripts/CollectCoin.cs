using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CollectCoin : MonoBehaviour
{


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player" && collision.GetType() == typeof(BoxCollider2D))
        {
            FindObjectOfType<GameManager>().addSingleCoin();
            Destroy(gameObject);
        }
    }



   
}
