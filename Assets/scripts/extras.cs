using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class extras : MonoBehaviour
{
    public GameObject flashlight;
    public float time = 5f;
    public bool flashy;
    private bool flashlightOn = false;

    void Start()
    {
        flashlight.SetActive(false);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.LeftAlt))
        {
            flashlightOn = !flashlightOn;
            flashlight.SetActive(flashlightOn);
        }
    }
}
