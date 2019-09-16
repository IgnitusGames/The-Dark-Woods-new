using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class Enemy_Move : MonoBehaviour
{
    // Start is called before the first frame update
    public int EnemySpeed;
    public int XMoveDirection;
    public bool facingRight = true;
    private Player_health player;

    public float force;
    Vector2 huidigePos;
    Vector2 playerPos;
    Vector2 startPos;
    public float hitTimer = 5;
    public float hitInterval;
    public float dash_time;
    public Animator animator;



    public float hitDistance;
    //public Player_health player_Health;


    private void Start()
    {

    }
    // Update is called once per frame
    void Update()
    {
        gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(XMoveDirection, 0) * EnemySpeed;
        hitTimer += Time.deltaTime;
    }
    private void OnCollisionEnter2D(Collision2D collision2d)
    {

        if (collision2d.gameObject.tag == "EnemyCollider")
        {

            Flip();
        }
        if (collision2d.gameObject.tag == "Player")
        {
            Debug.Log("pindakaas");
            collision2d.gameObject.GetComponent<Player_Health_Collectible>().Damage(1);



        }


    }
    public void Positie()
    {
        playerPos = GameObject.FindGameObjectWithTag("Player").transform.position;
        startPos = transform.position;
        Vector2 diff = (startPos - playerPos) / 2;
        //Debug.Log("start ois" + startPos.x);
        Debug.Log("start verschil" + diff.x);
    }
    public void Attack()
    {


        if (hitTimer >= hitInterval)
        {

        }

        if (facingRight == true && hitTimer >= hitInterval)
        {





            hitTimer = 0;

            GetComponent<Rigidbody2D>().AddForce(Vector2.right * force);

            Debug.Log("Aanval naar rechts");

            StartCoroutine(DashBack());

        }
        else if (facingRight == false && hitTimer >= hitInterval)
        {
            //EnemySpeed = 0;
            hitTimer = 0;

            GetComponent<Rigidbody2D>().AddForce(Vector2.left * force);
            GetComponent<Rigidbody2D>().AddForce(Vector2.right * (force));
            Debug.Log("Aanvalnaarl");
        }



    }

    //private void OnTriggerEnter2D(Collider2D trig)
    //{
    //    if (trig.gameObject.tag == "Player")
    //    {
    //        EnemySpeed = 20;
    //        Debug.Log("in endlevel zone");
    //        trig.GetComponent<Player_health>().Damage(1);

    //    }
    //    else EnemySpeed = 4;
    //}
    // Debug.Log("start huidige" + attackRange.x);

    //Debug.Log("start player" + playerPos.x);
    //Debug.Log("start attackRange" + attackRange.x);
    //        if (diff.x > )

    //if (diff.x > .x)
    //{
    //    EnemySpeed = 50;
    //    Debug.Log("in endlevel zone");
    //}

    //EnemySpeed = 20;

    //trig.GetComponent<Player_health>().Damage(1);
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
}
