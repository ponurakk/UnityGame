using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 5.5f;
    public LayerMask wallLayerMask;

    private Rigidbody2D rb;
    private Vector2 movement;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        float moveX = Input.GetAxisRaw("Horizontal");
        float moveY = Input.GetAxisRaw("Vertical");
        movement = new Vector2(moveX, moveY).normalized;
    }

    void FixedUpdate()
    {
        // Calculate the next position
        Vector2 nextPosition = rb.position + movement * moveSpeed * Time.fixedDeltaTime;

        // Perform a raycast to check for collisions
        RaycastHit2D hit = Physics2D.Raycast(rb.position, movement, moveSpeed * Time.fixedDeltaTime, wallLayerMask);

        // If there's no collision or if moving parallel to the wall, move the player
        if (hit.collider == null || Vector2.Dot(movement, hit.normal) >= 0)
        {
            rb.MovePosition(nextPosition);
        }
        else
        {
            // Otherwise, adjust the movement direction
            Vector2 adjustedMovement = Vector2.Perpendicular(hit.normal).normalized * Vector2.Dot(movement, Vector2.Perpendicular(hit.normal));
            nextPosition = rb.position + adjustedMovement * moveSpeed * Time.fixedDeltaTime;

            // Check if the adjusted movement direction is still blocked by a wall
            RaycastHit2D secondHit = Physics2D.Raycast(nextPosition, adjustedMovement, adjustedMovement.magnitude, wallLayerMask);

            if (secondHit.collider == null)
            {
                // If there's no collision after adjusting the movement direction, move the player
                rb.MovePosition(nextPosition);
            }
        }
    }
}
