using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [Header("Движение по горизонтали")]
    [SerializeField] private float moveSpeed = 10.0f;
    [SerializeField] private Vector2 direction;
    [SerializeField] private bool facingRight;

    [Header("Движение по вертикали")]
    [SerializeField] private float jumpSpeed = 15.0f;
    [SerializeField] private float jumpDelay = 0.25f;
    private float jumpTimer;

    [Header("Компоненты")]
    public Rigidbody2D rb;
    public Animator animator;
    public LayerMask groundLayer;
    public GameObject characterHolder;

    [Header("Физика")]
    [SerializeField] private float maxSpeed = 7.0f;
    [SerializeField] private float linearDrag = 4.0f;
    [SerializeField] private float gravity = 1;
    [SerializeField] private float fallMultiplier = 5.0f;

    [Header("Коллизия")]
    [SerializeField] private bool onGround = false;
    [SerializeField] private float groundLength = 0.6f;
    [SerializeField] private Vector3 colliderOffset;

 
    void Update()
    {       

        onGround = Physics2D.Raycast(transform.position + colliderOffset, Vector2.down, groundLength, groundLayer) || Physics2D.Raycast(transform.position - colliderOffset, Vector2.down, groundLength, groundLayer);

     

        if (Input.GetButtonDown("Jump"))
        {
           jumpTimer = Time.time + jumpDelay;
        }

        direction = new Vector2 (Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
        
    }

    private void FixedUpdate()
    {
        moveCharacter(direction.x);

        if(jumpTimer > Time.time && onGround) 
        {
            Jump();
        }

        ModifyPhysics();
    }

    void Jump()
    {
        rb.velocity = new Vector2(rb.velocity.x, 0);
        rb.AddForce(Vector2.up * jumpSpeed, ForceMode2D.Impulse);
        jumpTimer = 0;
       
    }

    void moveCharacter(float horizontal)
    {
        rb.AddForce(Vector2.right * horizontal * moveSpeed);

      //  animator.SetFloat("horizontal", Mathf.Abs(rb.velocity.x));

        if(horizontal > 0 && !facingRight || (horizontal < 0 && facingRight))
        {
            Flip();
        }

        if(Mathf.Abs(rb.velocity.x) > maxSpeed)
        {
            rb.velocity = new Vector2(Mathf.Sign(rb.velocity.x) * maxSpeed, rb.velocity.y);
        }
    }

    void ModifyPhysics()
    {
        bool changingDirections = (direction.x > 0 && rb.velocity.x < 0) || (direction.x < 0 && rb.velocity.x > 0);

        if (onGround)
        {
            if (Mathf.Abs(direction.x) < 0.4f || changingDirections)
            {
                rb.drag = linearDrag;

            }
            else
            {
                rb.drag = 0f;
            }
            rb.gravityScale = 0f;
        }
        else
        {
            rb.gravityScale = gravity;
            rb.drag = linearDrag * 0.15f;

            if(rb.velocity.y < 0)
            {
                rb.gravityScale = gravity * fallMultiplier;
            }
            else if (rb.velocity.y > 0 && !Input.GetButton("Jump"))
            {
                rb.gravityScale = gravity * (fallMultiplier / 2);
            }
        }
     
    }

    void Flip()
    {
        facingRight = !facingRight;

        transform.rotation = Quaternion.Euler(0f, facingRight ? 0 : 180, 0f);
    }   

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawLine(transform.position + colliderOffset, transform.position + colliderOffset + Vector3.down * groundLength);
        Gizmos.DrawLine(transform.position - colliderOffset, transform.position - colliderOffset + Vector3.down * groundLength);

    }
}
