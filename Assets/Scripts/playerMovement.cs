using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerMovement : MonoBehaviour
{
    public Rigidbody2D body;
    public bool canMove;
    public float speed = 15;

    void Start()
    {
        body = GetComponent<Rigidbody2D>();
        canMove = true;
    }
    void Update()
    {
        if (!canMove)
        {
            body.velocity = Vector2.zero;
            return;
        }

        Vector2 movementVector = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));

        if (canMove && movementVector != Vector2.zero)
        {
            body.MovePosition(body.position + movementVector * speed * Time.deltaTime);
        }
    }
}