using System.Collections;
using System.Collections.Generic;
using UnityEditor.Rendering;
using UnityEngine;

public class EnemyWalking : MonoBehaviour
{
    public float speed = 3.0f;
    private Rigidbody2D myBody;
    
    void Awake()
    {
        myBody = GetComponent<Rigidbody2D>();
    }

    
    void FixedUpdate()
    {
        myBody.velocity = new Vector2(speed, myBody.velocity.y);
    }

    
}
