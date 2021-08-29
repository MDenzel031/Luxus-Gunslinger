using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinPopScript : MonoBehaviour
{

    private Animator coinAnimation;

    private void Start()
    {
        coinAnimation = gameObject.GetComponent<Animator>();

    }

    private void Update()
    {
        if(coinAnimation.GetCurrentAnimatorStateInfo(0).normalizedTime > 1)
        {
            Destroy(gameObject);
        }
    }

}
