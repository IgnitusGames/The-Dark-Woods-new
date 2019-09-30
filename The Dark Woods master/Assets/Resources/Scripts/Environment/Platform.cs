using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Platform : MonoBehaviour
{

    public float dirX, moveSpeed = 3f;
   public bool moveRight = true;
   public bool face_right = true;




    void Update()
    {

        //gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(XMoveDirection, 0) * EnemySpeed;

     

        if (moveRight)
            transform.position = new Vector2(transform.position.x + moveSpeed * Time.deltaTime, transform.position.y);
        else
            transform.position = new Vector2(transform.position.x - moveSpeed * Time.deltaTime, transform.position.y);
    }

    private void OnTriggerEnter2D(Collider2D trig)
    {

        if (trig.gameObject.tag == "PlatformCollider")
        {
            Flip();
        }

    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Platform")
        {
           
        }
        if (collision.gameObject.tag == "movplat")
        {

        }
    }
    void Flip()
    {
        if (face_right == true)
        {
            //dirX = -1;
            //facingRight = !facingRight;
            moveRight = false;
            face_right = !face_right;
          
        }
        else
        {
            //// XMoveDirection = 1;
            // facingRight = false;
            face_right = true;
            moveRight = true;
     
        }
    }
}

