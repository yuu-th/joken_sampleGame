using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    Rigidbody2D rb;//Rigidbody2D�^�̕ϐ�
    [SerializeField] private float jump_power = 4;
    [SerializeField] private float max_speed = 5;
    [SerializeField] private float accelerate_force = 50;

    public GameObject fire_boll;
    bool is_field = false;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        this.gameObject.transform.position = new Vector2(-9, -2);
    }

    
    void FixedUpdate()
    {
        if(Input.GetAxisRaw("Horizontal") > 0)//�����E��󂪉�����Ă�����
        {
            if(rb.velocity.x < this.max_speed)//�����������ւ̑��x��5�ȉ��Ȃ�
            {
                //�E�ɗ͂������鏈��
                rb.AddForce(new Vector2(this.accelerate_force, 0));
            }
        } else if(Input.GetAxisRaw("Horizontal") < 0)//��������󂪉�����Ă�����
        {
            if( rb.velocity.x > -this.max_speed)
            {
                //���ɗ͂������鏈��
                rb.AddForce(new Vector2(-this.accelerate_force, 0));
            }
        } else if(Input.GetAxisRaw("Horizontal") == 0)//�ǂ�����������Ă��Ȃ��Ȃ�
        {
            rb.velocity = new Vector2(0, rb.velocity.y); //���x��0�ɐݒ�
        }

        if (Input.GetKey(KeyCode.Space) && is_field == true)
        {
            this.Jump();
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        ContactPoint2D contact_face = collision.contacts[0];
        if (collision.gameObject.tag == "Enemy")
        {           
            Debug.Log(contact_face.normal.y);
            if (contact_face.normal.y >= 0.7f)
            {
                this.StepOnEnemy(collision);
            } else
            {
                this.Die();
            }
        } else if(collision.gameObject.tag == "Goal")
        {
            //�S�[�����m
            SceneManager.LoadScene("ResultScene");
        }

        
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        ContactPoint2D contact_face = collision.contacts[0];
        //Debug.Log(contact_face.normal.y);
        if (contact_face.normal.y >= 0.5f)
        {
            is_field = true;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        is_field = false;
    }

    public void StepOnEnemy(Collision2D collision)
    {
        Destroy(collision.gameObject);

    }

    public void Die()
    {
        Destroy(gameObject);Destroy(gameObject);
        
    }

    public void Jump()
    {
        Debug.Log("jump");
        rb.AddForce(new Vector2(0, this.jump_power), ForceMode2D.Impulse);
    }

    public void fire()
    {
        GameObject obj = Instantiate(fire_boll, this.transform);
    }
}
