using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    Rigidbody2D rb;//Rigidbody2D型の変数
    bool is_field = false;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        this.gameObject.transform.position = new Vector2(-9, -2);
    }

    
    void Update()
    {
        if(Input.GetAxisRaw("Horizontal") > 0)//もし右矢印が押されていたら
        {
            if(rb.velocity.x < 7)//もし正方向への速度が7以下なら
            {
                //右に力を加える処理
                rb.AddForce(new Vector2(5, 0));
            }
        } else if(Input.GetAxisRaw("Horizontal") < 0)//もし左矢印が押されていたら
        {
            if( rb.velocity.x > -7)
            {
                //左に力を加える処理
                rb.AddForce(new Vector2(-5, 0));
            }
        } else if(Input.GetAxisRaw("Horizontal") == 0)//どっちも押されていないなら
        {
            rb.velocity = new Vector2(0, rb.velocity.y); //速度を0に設定
        }

        if (Input.GetKeyDown(KeyCode.Space) && is_field == true)
        {
            rb.AddForce(new Vector2(0, 7), ForceMode2D.Impulse);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        is_field = true;
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        is_field = false;
    }
}
