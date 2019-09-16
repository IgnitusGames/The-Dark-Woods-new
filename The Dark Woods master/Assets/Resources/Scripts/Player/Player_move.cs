using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Player_move : MonoBehaviour
{
    // Start is called before the first frame update


    public int playerSpeed = 10;
    public bool facingRight = true;
    public int playerJumpPower = 1250;
    public float moveX;
    public bool isGrounded;
    public int meerdereJumps;
    public int BounceHoogte;
    public float HitDistance;



    // Update is called once per frame
    void Update()
    {
        PlayerMove();
        PlayerRaycast();

    }

    void PlayerMove()
    {
        //Controls
        moveX = Input.GetAxis("Horizontal");
        if (isGrounded == true)
        {
            meerdereJumps = 0;
        }
        if (Input.GetButtonDown("Jump") && meerdereJumps < 3)
        {
            Jump();

            meerdereJumps = meerdereJumps + 1;

        }
        else if (Input.GetButtonDown("Jump") && isGrounded == true)
        {
            Jump();


        }

        //Direction
        if (moveX < 0.0f && facingRight == false)
        {
            FlipPlayer();
        }
        else if (moveX > 0.0f && facingRight == true)
        {
            FlipPlayer();
        }

       // physics
       gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(moveX * playerSpeed, gameObject.GetComponent<Rigidbody2D>().velocity.y);

    }
    void Jump()
    {
        gameObject.GetComponent<Rigidbody2D>().AddForce(Vector2.up * playerJumpPower);
        isGrounded = false;
    }

    void FlipPlayer()
    {
        facingRight = !facingRight;
        Vector2 localScale = gameObject.transform.localScale;
        localScale.x *= -1;
        transform.localScale = localScale;
    }

    void PlayerRaycast()
    {
        //rayUp
        RaycastHit2D rayUp = Physics2D.Raycast(transform.position, Vector2.up);
        if (rayUp != null && rayUp.collider != null && rayUp.distance < HitDistance && rayUp.collider.name == "Box_2")
        {
            Destroy(rayUp.collider.gameObject);
        }




        RaycastHit2D rayDown = Physics2D.Raycast(transform.position, Vector2.down);

        if (rayDown != null && rayDown.collider != null && rayDown.distance < HitDistance && rayDown.collider.tag == "enemy")
        {
            GetComponent<Rigidbody2D>().AddForce(Vector2.up * BounceHoogte);
            rayDown.collider.gameObject.GetComponent<Rigidbody2D>().AddForce(Vector2.right * 200);
            rayDown.collider.gameObject.GetComponent<Rigidbody2D>().gravityScale = 5;
            rayDown.collider.gameObject.GetComponent<Rigidbody2D>().freezeRotation = false;
            rayDown.collider.gameObject.GetComponent<BoxCollider2D>().enabled = false;
            rayDown.collider.gameObject.GetComponent<Enemy_Move>().enabled = false;


            //GetComponent<>

            Destroy(rayDown.collider.gameObject);
        }

       

        if (rayDown != null && rayDown.collider != null && rayDown.distance < HitDistance && rayDown.collider.tag != "enemy")
        {
            isGrounded = true;
           
        }
    }
}
