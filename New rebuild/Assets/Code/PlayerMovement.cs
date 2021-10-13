using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 10;
    private Rigidbody2D rb;
    private Vector2 movement;
    private SpriteRenderer SR;
    private Animator Anim;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        SR = GetComponent<SpriteRenderer>();
        Anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
            Vector2 moveInput = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
            movement = moveInput.normalized * speed;
            if (Input.GetAxisRaw("Horizontal") == 1)
            {
                Anim.SetInteger("KeyInput", 1);
            }
            else if (Input.GetAxisRaw("Horizontal") == -1)
            {
                Anim.SetInteger("KeyInput", -1);
            }
            else if (Input.GetAxisRaw("Vertical") == 1)
            {
                Anim.SetInteger("KeyInput", 2);
            }
            else if (Input.GetAxisRaw("Vertical") == -1)
            {
                Anim.SetInteger("KeyInput", -2);
            }
            else
            {
                Anim.SetInteger("KeyInput", 0);
            }
        if (Input.GetAxisRaw("Horizontal") != 0 && Input.GetAxisRaw("Vertical") != 0)
        {
            speed = 0;
            Anim.SetInteger("KeyInput", 0);
        }
        else
        {
            speed = 10;
        }

    }
    private void FixedUpdate()
    {
        rb.MovePosition(rb.position + movement * Time.fixedDeltaTime);
    }
}
