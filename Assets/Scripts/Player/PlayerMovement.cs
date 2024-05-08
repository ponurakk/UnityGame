using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {
    public int speed;
    private Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        Vector2 input = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
        Vector2 newPosition = new Vector2(transform.position.x, transform.position.y) + input * Time.deltaTime * speed;
        if (newPosition.y < 20 && newPosition.y > -20)
        {
            rb.MovePosition(new Vector2(transform.position.x, transform.position.y) + input * Time.deltaTime * speed);
        }
    }
}
