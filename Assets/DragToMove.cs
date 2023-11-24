using UnityEngine;

public class DragToMove : MonoBehaviour
{
    private bool isDragging = false;
    private Vector2 dragStartPosition;
    private Vector2 dragDelta;
    private Vector3 lastMoveDirection;

    public float moveSpeed = 5f;
    public float deceleration = 5f;

    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        // Set rigidbody constraints to freeze rotation
        rb.constraints = RigidbodyConstraints.FreezeRotation;
    }

    void Update()
    {
        // Check for input
        if (Input.GetMouseButtonDown(0))
        {
            // Mouse click or touch began
            isDragging = true;
            dragStartPosition = GetInputPosition();
        }
        else if (Input.GetMouseButtonUp(0))
        {
            // Mouse click or touch ended
            isDragging = false;
            lastMoveDirection = Vector3.zero; // Reset last move direction when releasing drag
        }

        // Update dragging position
        if (isDragging)
        {
            Vector2 currentInputPosition = GetInputPosition();
            dragDelta = currentInputPosition - dragStartPosition;
            dragStartPosition = currentInputPosition;

            // Move the player based on drag vector
            Vector3 moveDirection = new Vector3(dragDelta.x, 0, dragDelta.y).normalized;
            lastMoveDirection = moveDirection; // Update last move direction
            Vector3 moveVelocity = new Vector3(moveDirection.x * moveSpeed, rb.velocity.y, moveDirection.z * moveSpeed);
            rb.velocity = moveVelocity;
        }
        else
        {
            // Decelerate the player if not dragging
            Vector3 decelerationVelocity = new Vector3(lastMoveDirection.x * deceleration, 0, lastMoveDirection.z * deceleration);
            rb.velocity = Vector3.Lerp(rb.velocity, decelerationVelocity, deceleration * Time.deltaTime);
        }
    }

    Vector2 GetInputPosition()
    {
        // Check if using mouse or touch input
        if (Input.touchSupported && Input.touchCount > 0)
        {
            // Use touch input
            return Input.GetTouch(0).position;
        }
        else
        {
            // Use mouse input
            return new Vector2(Input.mousePosition.x, Input.mousePosition.y);
        }
    }
}
