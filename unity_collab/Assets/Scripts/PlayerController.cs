using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
   
    [SerializeField]private float speed = 8.0f;
    [SerializeField]private float jumpForce = 10.0f;
    
    [SerializeField] private Rigidbody2D rb;
    private bool isGrounded;
    private string GROUND_TAG = "Ground";
    private SpriteRenderer sr;
    private float movementX;
    private float horizontal;
    bool doubleJump;

    private bool canDash = true;
    private bool isDashing;
    private float dashingPower = 24f;
    private float dashingTime = 0.2f;
    private float dashingCooldown = 1f;
    [SerializeField] private TrailRenderer tr;
  

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
    }


    void PlayerJump()
    {
        if(Input.GetButtonDown("Jump"))
        {
            
            if(isGrounded)
            {
                isGrounded = false;
                rb.velocity = new Vector2(rb.velocity.x, jumpForce);
                doubleJump = true;
            }
            else if(doubleJump)
            {
                isGrounded = false;
                rb.velocity = new Vector2(rb.velocity.x, jumpForce);
                doubleJump = false;
            }
            /*isGrounded = false;
            rb.AddForce(new Vector2(0f, jumpForce), ForceMode2D.Impulse);*/

        }
    }

    private void OnCollisionEnter2D(Collision2D collision2D)
    {
        if(collision2D.gameObject.CompareTag(GROUND_TAG))
        {
            isGrounded = true;
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
