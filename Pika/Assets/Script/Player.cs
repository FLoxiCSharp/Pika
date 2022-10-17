using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private Rigidbody2D rb;
    private float MoveX = 0f;
    public float speed = 1f;
    public float MaxSpeed = 1f;
    public float jumpForce = 5f;
    public static bool isGrounded = false;
    public bool isRunning = false;
    public Transform groundCheck;
    private Animator anim;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }
    private void FixedUpdate()
    {
        Vector2 targetVelocity = new Vector2(MoveX * MaxSpeed, rb.velocity.y);
        rb.velocity = targetVelocity;
    }
    void Update()
    {
        MoveX = Input.GetAxisRaw("Horizontal") * speed;
        Flip();
        Jump_Run();
        GroundCheck();
        Animation();
    }
    private void Animation()
    {
        if (!isGrounded)
        {
            anim.SetInteger("AnimComp", 3);
        }
        else if (isGrounded && isRunning && MoveX != 0 && Input.GetKey(KeyCode.A) || isGrounded && isRunning && MoveX != 0 && Input.GetKey(KeyCode.D))
        {
            anim.SetInteger("AnimComp", 4);
        }
        else if (isGrounded && !isRunning && MoveX != 0 && Input.GetKey(KeyCode.A) || isGrounded && !isRunning && MoveX != 0 && Input.GetKey(KeyCode.D))
        {
            anim.SetInteger("AnimComp", 2);
        }
        else
        {
            anim.SetInteger("AnimComp", 1);
        }

    }

    private void Flip()
    {
        if (Input.GetAxis("Horizontal") > 0)
        {
            transform.localRotation = Quaternion.Euler(0, 0, 0);
        }
        if (Input.GetAxis("Horizontal") < 0)
        {
            transform.localRotation = Quaternion.Euler(0, 180, 0);
        }
    }
    private void Jump_Run()
    {
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            rb.AddForce(transform.up * jumpForce, ForceMode2D.Impulse);
        }
        if (Input.GetKey(KeyCode.LeftShift) && isGrounded)
        {
            MaxSpeed = 9f;
            isRunning = true;
        }
        if (Input.GetKeyUp(KeyCode.LeftShift))
        {
            MaxSpeed = 4f;
            isRunning = false;
        }
    }
    public void GroundCheck()
    {
        Collider2D[] colliders = Physics2D.OverlapCircleAll(groundCheck.position, 0.2f, Physics2D.DefaultRaycastLayers, -100, 18f);
        print(colliders.Length);
        if (colliders.Length > 1)
        {
            isGrounded = true;
        }
        
        else
        {
            isGrounded = false;
        }
    }
}
