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
            Anim.SetBool("isLeft", false);
            Anim.SetBool("isRight", true);
        }
        if (Input.GetAxisRaw("Horizontal") == -1)
        {
            Anim.SetBool("isLeft", true);
            Anim.SetBool("isRight", false);
        }
    }
    private void FixedUpdate()
    {
        rb.MovePosition(rb.position + movement * Time.fixedDeltaTime);
    }
}
