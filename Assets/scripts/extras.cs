using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class extras : MonoBehaviour
{
    public GameObject flashlight;
    public float time = 5f;
    public bool flashy;
    private bool flashlightOn = false;
    public List<GameObject> gameObjects;

    void Start()
    {
        flashlight.SetActive(false);
        foreach (GameObject go in gameObjects)
        {
            go.SetActive(false);
        }
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.LeftAlt))
        {
            flashlightOn = !flashlightOn;
            flashlight.SetActive(flashlightOn);
        }
    }

    public void accept()
    {
        foreach (GameObject obj in gameObjects)
        {
            obj.SetActive(true);
        }
    }

}
