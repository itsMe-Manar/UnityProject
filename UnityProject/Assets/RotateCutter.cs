using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateObject : MonoBehaviour
{
    public float rotationSpeed = 100f; // Speed of rotation in degrees per second

    // Update is called once per frame
    void Update()
    {
        // Rotate the object around its Z axis
        transform.Rotate(0, 0, rotationSpeed * Time.deltaTime);
    }
}
