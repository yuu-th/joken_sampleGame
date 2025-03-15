using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    Rigidbody2D rb;//Rigidbody2D型の変数
    bool is_field = false;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        this.gameObject.transform.position = new Vector2(-9, -2);
    }

    
    void FixedUpdate()
    {
        if(Input.GetAxisRaw("Horizontal") > 0)//もし右矢印が押されていたら
        {
            if(rb.velocity.x < 5)//もし正方向への速度が7以下なら
            {
                //右に力を加える処理
                rb.AddForce(new Vector2(50, 0));
            }
        } else if(Input.GetAxisRaw("Horizontal") < 0)//もし左矢印が押されていたら
        {
            if( rb.velocity.x > -5)
            {
                //左に力を加える処理
                rb.AddForce(new Vector2(-50, 0));
            }
        } else if(Input.GetAxisRaw("Horizontal") == 0)//どっちも押されていないなら
        {
            rb.velocity = new Vector2(0, rb.velocity.y); //速度を0に設定
        }

        if (Input.GetKey(KeyCode.Space) && is_field == true)
        {
            Debug.Log("junp");
            rb.AddForce(new Vector2(0, 4), ForceMode2D.Impulse);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Enemy")
        {           
            ContactPoint2D contact_face = collision.contacts[0];
            Debug.Log(contact_face.normal.y);
            if (contact_face.normal.y >= 0.7f)
            {
                Destroy(collision.gameObject);
            } else
            {
                Destroy(gameObject);
            }
        } else if(collision.gameObject.tag == "Goal")
        {
            //ゴール検知
            SceneManager.LoadScene("ResultScene");
        }
        is_field = true;
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        is_field = false;
    }
}
