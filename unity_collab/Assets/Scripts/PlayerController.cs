using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private float horizontal;
    [SerializeField]private float speed = 8.0f;
    [SerializeField]private float jumpForce = 10.0f;
    private bool isFacingRight = true;
    private float movementX;
    [SerializeField] private Rigidbody2D rb;

    
    void Update()
    {
        PlayerMoveKeyboard();
    }

    void PlayerMoveKeyboard()
    {
        movementX = Input.GetAxisRaw("Horizontal");

        transform.position += new Vector3(movementX, 0, 0) * Time.deltaTime * speed;
    }
}
