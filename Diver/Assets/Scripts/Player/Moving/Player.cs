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
    [SerializeField] public bool onGround = false;
    [SerializeField] private float groundLength = 0.6f;
    [SerializeField] private Vector3 colliderOffset;

    [Header("Физика крюка")]
    public Vector2 ropeHook;
    public float swingForce = 4f;
    public bool isSwinging;

    public bool isDead = false;


    void Update()
    {
        if (!CanMove())        
            return;     

        onGround = Physics2D.Raycast(transform.position + colliderOffset, Vector2.down, groundLength, groundLayer) || Physics2D.Raycast(transform.position - colliderOffset, Vector2.down, groundLength, groundLayer);

     

        if (Input.GetButtonDown("Jump"))
        {
           jumpTimer = Time.time + jumpDelay;
        }

        direction = new Vector2 (Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
        
    }

    bool CanMove()
    {
        bool can = true;

        if(FindFirstObjectByType<InteractionSystem>().isExamining)
            can = false;

        //if (FindFirstObjectByType<InventorySystem>().isOpen)
        //    can = false;

        if(isDead) 
            can = false;

        return can;
    }

    private void FixedUpdate()
    {
        if (!CanMove())
            return;

        if (isSwinging)
        {
            rb.mass = 0.5f;

            // Code for swinging behavior
            // This part should be integrated into your existing FixedUpdate function

            // 1 - получаем нормализованный вектор направления от игрока к точке крюка
            var playerToHookDirection = (ropeHook - (Vector2)transform.position).normalized;

            // 2 - Инвертируем направление, чтобы получить перпендикулярное направление
            Vector2 perpendicularDirection;
            if (direction.x < 0)
            {
                perpendicularDirection = new Vector2(-playerToHookDirection.y, playerToHookDirection.x);
                var leftPerpPos = (Vector2)transform.position - perpendicularDirection * -2f;
                Debug.DrawLine(transform.position, leftPerpPos, Color.green, 0f);
            }
            else
            {
                perpendicularDirection = new Vector2(playerToHookDirection.y, -playerToHookDirection.x);
                var rightPerpPos = (Vector2)transform.position + perpendicularDirection * 2f;
                Debug.DrawLine(transform.position, rightPerpPos, Color.green, 0f);
            }

            var force = perpendicularDirection * swingForce;
            rb.AddForce(force, ForceMode2D.Force);
        }
        else
        {
            rb.mass = 1f;

            moveCharacter(direction.x);

            if (jumpTimer > Time.time && onGround)
            {
                Jump();
            }

            ModifyPhysics();
        }
    }

    void Jump()
    {
        rb.velocity = new Vector2(rb.velocity.x, 0);
        rb.AddForce(Vector2.up * jumpSpeed, ForceMode2D.Impulse);
        jumpTimer = 0;

       // StartCoroutine(JumpSqueeze(0.5f, 1.1f, 0.1f));
       
    }

    void moveCharacter(float horizontal)
    {
        if (!CanMove())
            return;

        rb.AddForce(Vector2.right * horizontal * moveSpeed);

        animator.SetFloat("horizontal", Mathf.Abs(rb.velocity.x));

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

    //IEnumerator JumpSqueeze(float xSqueeze, float ySqueeze, float seconds)
    //{
    //    Vector3 originalSize = Vector3.one;
    //    Vector3 newSize = new Vector3(xSqueeze, ySqueeze, originalSize.z);
    //    float t = 0f;
    //    while (t <= 1.0)
    //    {
    //        t += Time.deltaTime / seconds;
    //        characterHolder.transform.localScale = Vector3.Lerp(originalSize, newSize, t);
    //        yield return null;
    //    }
    //    t = 0f;
    //    while (t <= 1.0)
    //    {
    //        t += Time.deltaTime / seconds;
    //        characterHolder.transform.localScale = Vector3.Lerp(newSize, originalSize, t);
    //        yield return null;
    //    }

    //}

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawLine(transform.position + colliderOffset, transform.position + colliderOffset + Vector3.down * groundLength);
        Gizmos.DrawLine(transform.position - colliderOffset, transform.position - colliderOffset + Vector3.down * groundLength);

    }

    public void Die()
    {
        isDead = true;
        FindFirstObjectByType<LevelManager>().Restart();
    }

    public void ResetPlayer()
    {
        rb.velocity = Vector2.zero; // Reset velocity to zero
        rb.gravityScale = gravity;  // Reset gravity scale
        rb.drag = linearDrag;       // Reset drag

        isDead = false;             // Reset death state
        direction = Vector2.zero;   // Reset movement direction
    }
}
