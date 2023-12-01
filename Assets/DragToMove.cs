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
        rb.constraints = RigidbodyConstraints.FreezeRotation;
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            isDragging = true;
            dragStartPosition = GetInputPosition();
        }
        else if (Input.GetMouseButtonUp(0))
        {
            isDragging = false;
            lastMoveDirection = Vector3.zero; 
        }

        if (isDragging)
        {
            Vector2 currentInputPosition = GetInputPosition();
            dragDelta = currentInputPosition - dragStartPosition;
            dragStartPosition = currentInputPosition;

            Vector3 moveDirection = new Vector3(dragDelta.x, 0, dragDelta.y).normalized;
            lastMoveDirection = moveDirection; 
            Vector3 moveVelocity = new Vector3(moveDirection.x * moveSpeed, rb.velocity.y, moveDirection.z * moveSpeed);
            rb.velocity = moveVelocity;
        }
        else
        {
            Vector3 decelerationVelocity = new Vector3(lastMoveDirection.x * deceleration, 0, lastMoveDirection.z * deceleration);
            rb.velocity = Vector3.Lerp(rb.velocity, decelerationVelocity, deceleration * Time.deltaTime);
        }
    }

    Vector2 GetInputPosition()
    {
        if (Input.touchSupported && Input.touchCount > 0)
        {
            return Input.GetTouch(0).position;
        }
        else
        {
            return new Vector2(Input.mousePosition.x, Input.mousePosition.y);
        }
    }
}
