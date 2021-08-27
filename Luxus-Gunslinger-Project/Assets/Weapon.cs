using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{

    public Transform firePoint;
    public GameObject bulletPrefab;
    public Animator weaponAnimation;
    bool fireAnimation = false;


    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            fireAnimation = !fireAnimation;
            weaponAnimation.SetBool("isFiring", fireAnimation);
            Shoot();
        }

    }

    void Shoot()
    {
        
        Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        FindObjectOfType<AudioManager>().playSound("gunShot");




    }
}
