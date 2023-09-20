using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraView : MonoBehaviour
{
    public float sensitivity = 2.0f;
    private float maxYRotation = 20.0f;


    private float rotationX = 0;

    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    private void Update()
    {
        float mouseX = Input.GetAxis("Mouse X");
        float mouseY = Input.GetAxis("Mouse Y");

        transform.localRotation *= Quaternion.Euler(0, mouseX * sensitivity, 0);

        rotationX -= mouseY * sensitivity;
        rotationX = Mathf.Clamp(rotationX, -20, maxYRotation);

        Camera.main.transform.localRotation = Quaternion.Euler(rotationX, 0, 0);
    }
}
