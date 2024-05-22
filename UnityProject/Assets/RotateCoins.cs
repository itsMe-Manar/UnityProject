using UnityEngine;

public class CoinRotation : MonoBehaviour
{
    // Rotation speed in degrees per second
    public float rotationSpeed = 100f;

    // Update is called once per frame
    void Update()
    {
        // Rotate the coin around its local up axis (Y-axis)
        transform.Rotate(Vector3.up, rotationSpeed * Time.deltaTime);
    }
}
