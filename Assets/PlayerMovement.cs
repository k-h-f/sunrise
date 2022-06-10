using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    public float moveSpeed = 5f;
    public Rigidbody2D rb;
    public Animator animator;

    Vector2 movement;

    // Update is called once per frame
    void Update()
    {
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");
        animator.SetFloat("Horizontal", movement.x);
        animator.SetFloat("Vertical", movement.y);
        animator.SetFloat("Speed", movement.sqrMagnitude);

        if (movement.x > 0f && movement.y > 0f)
        {
            transform.localRotation = Quaternion.Euler(0, 0, -40);
        }
        else if (movement.x > 0f && movement.y < 0f)
        {
            transform.localRotation = Quaternion.Euler(0, 0, 40);
        }
        else if (movement.x < 0f && movement.y > 0f)
        {
            transform.localRotation = Quaternion.Euler(180, 0, 150);
        }
        else if (movement.x < 0f && movement.y < 0f)
        {
            transform.localRotation = Quaternion.Euler(180, 0, -150);
        }
        else
        {
            transform.localRotation = Quaternion.Euler(0, 0, 0);
        }

        if (movement.x > 0f)
        {
            transform.localScale = new Vector2(-1, 1);
        }
        else if(movement.x < 0f)
        {
            transform.localScale = new Vector2(1, 1);
        }
        Debug.Log(movement);
    }

    void FixedUpdate()
    {
        rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime);
    }
}
