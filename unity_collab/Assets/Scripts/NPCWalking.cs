using UnityEngine;

public class NPCWalking : MonoBehaviour
{
    public float moveSpeed = 2f;
    private bool movingRight = true;
    private Rigidbody2D rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        // Check if the NPC is at the edge of the platform
        if ((movingRight && transform.position.x >= 4f) || (!movingRight && transform.position.x <= -4f))
        {
            // Change direction
            movingRight = !movingRight;
            FlipNPC();
        }

        // Move the NPC
        if (movingRight)
        {
            rb.velocity = new Vector2(moveSpeed, rb.velocity.y);
        }
        else
        {
            rb.velocity = new Vector2(-moveSpeed, rb.velocity.y);
        }
    }

    private void FlipNPC()
    {
        // Flip the NPC's sprite to face the appropriate direction
        Vector3 scale = transform.localScale;
        scale.x *= -1;
        transform.localScale = scale;
    }
}
