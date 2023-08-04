using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    //character movement on x axis
    [SerializeField] private float speed = 8.0f;
    [SerializeField] private float jumpForce = 10.0f;
    [SerializeField] private Rigidbody2D rb;
    private SpriteRenderer sr;
    private float movementX;
    private float horizontal;
    
    //character jump
    bool doubleJump;
    private bool isGrounded;
    private string GROUND_TAG = "Ground";

    //character dash
    private bool canDash = true;
    private bool isDashing;
    private float dashingPower = 24f;
    private float dashingTime = 0.2f;
    private float dashingCooldown = 1f;
    [SerializeField] private TrailRenderer tr;

    //character facing direction
    public bool facingRight;

    //animation
    public Animator animator;
  

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if(isDashing)
        {
            return;
        }

        PlayerMoveKeyboard();
        PlayerJump();

        if(Input.GetKeyDown(KeyCode.LeftShift) && canDash)
        {
            StartCoroutine(Dash());
        }

        animator.SetFloat("Speed", Mathf.Abs(movementX));
        
    }
    private void FixedUpdate()
    {
        if(isDashing)
        {
            return;
        }
    }

    
    

    void PlayerMoveKeyboard()
    {
        movementX = Input.GetAxisRaw("Horizontal");

        transform.position += new Vector3(movementX, 0, 0) * Time.deltaTime * speed;
        if(movementX > 0.5)
        {
            facingRight = true;
        }
        if(movementX < -0.5) 
        {
            facingRight = false;
        }

        if(facingRight)
        {
            transform.localScale = new Vector2(1,1);
        }
        else if(!facingRight)
        {
            transform.localScale = new Vector2(-1,1);
        }
    }

    

    void PlayerJump()
    {
        
        if(Input.GetButtonDown("Jump") && isGrounded)
        {
            
        animator.SetBool("IsJumping", true);
        rb.velocity = new Vector2(rb.velocity.x, jumpForce);
        isGrounded = false;

    
        }
        
    }

    private void OnCollisionEnter2D(Collision2D collision2D)
    {
        if(collision2D.gameObject.CompareTag(GROUND_TAG))
        {
            isGrounded = true;
            animator.SetBool("IsJumping", false);
        }
    }

    private IEnumerator Dash()
    {
        canDash = false;
        isDashing = true;
        float originalGravity = rb.gravityScale;
        rb.gravityScale = 0f;
        rb.velocity = new Vector2(transform.localScale.x * dashingPower, 0f);
        tr.emitting = true;
        yield return new WaitForSeconds(dashingTime);
        tr.emitting = false;
        rb.gravityScale = originalGravity;
        isDashing = false;
        yield return new WaitForSeconds(dashingCooldown);
        canDash = true;

    }

    




}
