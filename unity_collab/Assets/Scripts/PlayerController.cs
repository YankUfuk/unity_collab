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

    

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    void Update()
    {
        PlayerMoveKeyboard();
        PlayerJump();
        
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

    

    




}
