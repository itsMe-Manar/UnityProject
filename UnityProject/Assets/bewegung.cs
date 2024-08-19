using UnityEngine;

public class MovingPlatform : MonoBehaviour
{
    public float moveSpeed = 2f;
    public float moveDistance = 2f;
    public string moveDirection = "vertical"; // "horizontal" or "vertical"
    public bool moveOnlyRight = true; // Controls horizontal movement direction

    private Vector3 startPosition;
    private bool movingAwayFromStart = true;

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
        if (movingAwayFromStart)
        {
            position.y += moveSpeed * Time.deltaTime;
            if (position.y >= startPosition.y + moveDistance)
            {
                movingAwayFromStart = false;
            }
        }
        else
        {
            position.y -= moveSpeed * Time.deltaTime;
            if (position.y <= startPosition.y)
            {
                movingAwayFromStart = true;
            }
        }
        transform.position = position;
    }

    private void MoveHorizontal()
    {
        Vector3 position = transform.position;
        if (moveOnlyRight)
        {
            // Move to the right and then return to the start position
            if (movingAwayFromStart)
            {
                position.x += moveSpeed * Time.deltaTime;
                if (position.x >= startPosition.x + moveDistance)
                {
                    movingAwayFromStart = false;
                }
            }
            else
            {
                position.x -= moveSpeed * Time.deltaTime;
                if (position.x <= startPosition.x)
                {
                    movingAwayFromStart = true;
                }
            }
        }
        else
        {
            // Move in both directions (right and left)
            if (movingAwayFromStart)
            {
                position.x += moveSpeed * Time.deltaTime;
                if (position.x >= startPosition.x + moveDistance)
                {
                    movingAwayFromStart = false;
                }
            }
            else
            {
                position.x -= moveSpeed * Time.deltaTime;
                if (position.x <= startPosition.x - moveDistance)
                {
                    movingAwayFromStart = true;
                }
            }
        }
        transform.position = position;
    }
}
