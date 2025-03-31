using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    Rigidbody2D rb;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        last_pos = transform.position;
    }

    Vector3 last_pos;
    int vector_pm = -1;
    void FixedUpdate()
    {
        if (last_pos == transform.position)
        {
            this.transform.localScale = new Vector3(this.transform.localScale.x * -1, 1, 1);
            vector_pm *= -1;
        }
        else
        {
            last_pos = this.transform.position;
        }
        Debug.Log(vector_pm);
        if(Math.Abs(rb.velocity.x) < 2)
        {
            rb.AddForce(this.transform.right*-50*vector_pm);
        }
    }
}
