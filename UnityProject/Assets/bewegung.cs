using UnityEngine;

public class MovingPlatform : MonoBehaviour
{
    public float moveSpeed = 2f;
    public float moveDistance = 2f;
    public string moveDirection = "vertical"; // "horizontal" oder "vertical"

    private Vector3 startPosition;
    private bool movingUpOrRight = true;

    void Start()
    {
        startPosition = transform.position;
    }

    void Update()
    {
        if (moveDirection.ToLower() == "vertical")
        {
            MoveVertical();
        }
        else if (moveDirection.ToLower() == "horizontal")
        {
            MoveHorizontal();
        }
    }

    private void MoveVertical()
    {
        Vector3 position = transform.position;
        if (movingUpOrRight)
        {
            position.y += moveSpeed * Time.deltaTime;
            if (position.y >= startPosition.y + moveDistance)
            {
                movingUpOrRight = false;
            }
        }
        else
        {
            position.y -= moveSpeed * Time.deltaTime;
            if (position.y <= startPosition.y - moveDistance)
            {
                movingUpOrRight = true;
            }
        }
        transform.position = position;
    }

    private void MoveHorizontal()
    {
        Vector3 position = transform.position;
        if (movingUpOrRight)
        {
            position.x += moveSpeed * Time.deltaTime;
            if (position.x >= startPosition.x + moveDistance)
            {
                movingUpOrRight = false;
            }
        }
        else
        {
            position.x -= moveSpeed * Time.deltaTime;
            if (position.x <= startPosition.x - moveDistance)
            {
                movingUpOrRight = true;
            }
        }
        transform.position = position;
    }
}
