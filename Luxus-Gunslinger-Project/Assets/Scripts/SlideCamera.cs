using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlideCamera : MonoBehaviour
{

    public float slideSpeed = 30f;
    public Transform camera;

    private void Awake()
    {
    }


    private void Update()
    {
        camera.position += new Vector3(slideSpeed * Time.deltaTime, 0f, 0f);
    }
}
