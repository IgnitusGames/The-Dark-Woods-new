using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class Shroom_Dash_Enemy_Move : MonoBehaviour
{
    // Start is called before the first frame update
    public int EnemySpeed;
    public int XMoveDirection;
    public bool facingRight = true;
    private Player_Health_Collectible player;

    public float force;
    public float hitTimer = 5;
    public float hitInterval;
    public float dash_time;
    public Animator animator;
    public float hitDistance;



    private void Start()
    {

    }

    void Update()
    {
        gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(XMoveDirection, 0) * EnemySpeed;
        hitTimer += Time.deltaTime;
    }

    //Flip op collision met muur, damage op collision player
    private void OnCollisionEnter2D(Collision2D collision2d)
    {

        if (collision2d.gameObject.tag == "EnemyCollider")
        {

            Flip();
        }
        if (collision2d.gameObject.tag == "Player")
        {
           
            collision2d.gameObject.GetComponent<Player_Health_Collectible>().Damage(1);
        }


    }

    public void Attack()
    {

        //
        if (facingRight == true && hitTimer >= hitInterval)
        {





            hitTimer = 0;


            GetComponent<Rigidbody2D>().AddForce(Vector2.right * force);

            FindObjectOfType<AudioManager>().Play("EnemyShroomDashSound");

            StartCoroutine(DashBack());

        }
        else if (facingRight == false && hitTimer >= hitInterval)
        {




            hitTimer = 0;


            GetComponent<Rigidbody2D>().AddForce(Vector2.left * force);

            Debug.Log("Aanval naar rechts");

            StartCoroutine(DashBack2());
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
            facingRight = false;
            Vector2 localScale = gameObject.transform.localScale;
            localScale.x *= -1;
            transform.localScale = localScale;
        }
    }
    IEnumerator DashBack()
    {

        yield return new WaitForSeconds(dash_time);

        GetComponent<Rigidbody2D>().AddForce(Vector2.left * (force * 3));

    }
    IEnumerator DashBack2()
    {

        yield return new WaitForSeconds(dash_time);

        GetComponent<Rigidbody2D>().AddForce(Vector2.right * (force * 3));

    }
}
