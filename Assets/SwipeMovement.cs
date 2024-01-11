using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using TMPro;
using UnityEngine;

public class SwipeMovement : MonoBehaviour
{
    [Range(0f, 45f)]
    public float angleThreshold;
    public float speedMultiplier;
    public TextMeshProUGUI textMeshProUGUI;
    Vector2 initialPosition;
    Vector2 direction;

    Rigidbody rb;
    void Start()
    {
        direction = Vector2.left;
        rb = GetComponent<Rigidbody>();
        rb.velocity = -Vector3.left;
    }

    bool angleMatchesWithinThreshold(float targetAngle, float actualAngle)
    {
        if (Mathf.Abs(targetAngle - actualAngle) < angleThreshold)
        {
            return true;
        }
        // Account for angles 360 and 0 being the same thing.
        else if (Mathf.Abs(targetAngle - actualAngle - 360) < angleThreshold)
        {
            return true;
        }
        return false;
    }

    void Update()
    {
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);
            if (touch.phase == TouchPhase.Began)
            {
                initialPosition = touch.position;
            }
            if (touch.phase == TouchPhase.Moved)
            {
                var displacement = touch.position - initialPosition;
                var angle_radians = Mathf.Atan2(displacement.y, displacement.x);
                var angle_degrees = angle_radians * Mathf.Rad2Deg;
                if (angle_degrees < 0)
                {
                    angle_degrees += 360;
                }
                textMeshProUGUI.text = angle_degrees.ToString();

                Vector2 nextDirection = Vector2.zero;
                if (angleMatchesWithinThreshold(0, angle_degrees))
                {
                    nextDirection = Vector2.right;
                }
                else if (angleMatchesWithinThreshold(90, angle_degrees))
                {
                    nextDirection = Vector2.up;
                }
                else if (angleMatchesWithinThreshold(180, angle_degrees))
                {
                    nextDirection = Vector2.left;
                }
                else if (angleMatchesWithinThreshold(270, angle_degrees))
                {
                    nextDirection = Vector2.down;
                }
                if (nextDirection != Vector2.zero)
                {
                    direction = nextDirection;
                }
            }
        }

        var newVelocity = -new Vector3(direction.x, 0, direction.y) * speedMultiplier;
        rb.velocity = newVelocity;
    }
}
