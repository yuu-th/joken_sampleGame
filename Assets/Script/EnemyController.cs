using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    Rigidbody2D rb;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    
    void FixedUpdate()
    {
        if(rb.velocity.x > -2)
        {
            rb.AddForce(new Vector2(-50, 0));
        }
    }
}
