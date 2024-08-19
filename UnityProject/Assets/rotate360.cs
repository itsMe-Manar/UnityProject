using UnityEngine;

public class RotatingObject : MonoBehaviour
{
    public float rotationSpeed = 100f; // Speed of rotation (degrees per second)

    private Vector3 startPosition;

    private void Start()
    {
        // Save the start position of the player
        startPosition = GameObject.FindGameObjectWithTag("Player").transform.position;
    }

    void Update()
    {
        // Rotate the object continuously
        transform.Rotate(Vector3.forward, rotationSpeed * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            // Reset the player's position to the start position
            other.transform.position = startPosition;
        }
    }
}
