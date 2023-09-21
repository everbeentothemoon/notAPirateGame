using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dayNNite : MonoBehaviour
{
    Vector3 rotation = Vector3.zero;
    float degreesPerSec = 6;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        rotation.x = degreesPerSec * Time.deltaTime;
        transform.Rotate(rotation, Space.World);
    }
}
