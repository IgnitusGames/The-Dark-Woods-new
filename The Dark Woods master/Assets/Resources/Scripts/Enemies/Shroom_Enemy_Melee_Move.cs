using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shroom_Enemy_Melee_Move : MonoBehaviour
{
    // Start is called before the first frame update
    public int EnemySpeed;
    public int XMoveDirection;
    public bool facingRight = true;
    private Player_Health_Collectible player;
    public float raycast_hit_offset;
    public Animator animator;
    public float force;
    public float hitTimer = 5;
    public float hitInterval;
    public float attacktimer = 20.0f;
    public float hitDistance;

    void Update()
    {
        RaycastHit2D hit = Physics2D.Raycast(new Vector2(transform.position.x + raycast_hit_offset, transform.position.y), new Vector2(XMoveDirection, 0));
        gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(XMoveDirection, 0) * EnemySpeed;

        // Debug.Log(hit.distance);

        if (hit.distance < 1.0f && hit.collider.tag == "EnemyCollider")
        {
            Flip();

            //  player_Health.Die();    
        }




        Attack();

        // EnemySpeed = 4;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "EnemyCollider")
        {
            Flip();
        }
    }


    public void Attack()
    {
        hitTimer += Time.deltaTime;
        //RaycastHit2D hit = Physics2D.Raycast(transform.position, new Vector2(XMoveDirection, 0));
        RaycastHit2D hit = Physics2D.Raycast(new Vector2(transform.position.x + raycast_hit_offset, transform.position.y), new Vector2(XMoveDirection, 0));

        //bulletTimer >= bulletInterval


        if (hit.collider.tag == "Player" && hit.distance < hitDistance && hitTimer >= hitInterval)
        {

            EnemySpeed = 0;
            hit.collider.gameObject.GetComponent<Player_Health_Collectible>().Damage(1);
            hitTimer = 0;
            print("valalalltl aana");
            FindObjectOfType<AudioManager>().Play("ShroomEnemyAttack");
            animator.SetBool("IsAttack", true);
        }
        else if (hit.collider.tag != "Player")
        {
            EnemySpeed = 4;
            //animator.SetBool("IsAttack", false);
        }



    }


    void Flip()
    {
        if (XMoveDirection > 0)
        {
            XMoveDirection = -1;
            facingRight = !facingRight;
            Vector2 localScale = gameObject.transform.localScale;
            localScale.x *= -1;
            transform.localScale = localScale;
        }
        else
        {
            XMoveDirection = 1;

            Vector2 localScale = gameObject.transform.localScale;
            localScale.x *= -1;
            transform.localScale = localScale;
        }
    }

}

