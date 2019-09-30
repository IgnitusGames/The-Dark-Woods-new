using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(BoxCollider2D))]
public class PlayerLogic : MonoBehaviour
{
    //Variables
    public Animator animator;
    public Joystick the_joystick;
    public int player_speed = 10;
    public int strong_jump_power = 500;
    public int normal_jump_power = 250;
    public int player_max_health;
    public int player_curr_health;
    public int player_mana;
    public int y_death_level;
    public float ray_origin_y;
    public float hit_distance;
    public bool is_grounded = true;
    public bool jump;
    public float force = 100;
    private Rigidbody2D rb2d;
    public int jump_count = 0;

  

    private float horizontal_move;
    public bool going_right = true;
    // Update is called once per frame
    private void Start()
    {
        //StartCoroutine(KnockBack(0.02f, 350, transform.position));
    }
    void Update()
    {
        Movement();
       if (is_grounded)
        {
            jump_count = 0;
        }
        if (Input.GetButton("Jump"))
        {
            Jump();
            print("jump");
           // Jump2();
        }
        //if (IsGrounded == false)
        //{
        //    animator.SetBool("is_jumping", true);
        //}
        if (player_max_health > player_curr_health)
        {
            player_curr_health = player_max_health;
        }
        if (player_curr_health <= 0)
        {
            //Die();
        }
        //Attacks
        if (Input.touchCount > 0)
        {
            if (DialogueManager.is_in_dialogue)
            {
                if(Input.GetTouch(0).phase == TouchPhase.Ended)
                {
                    FindObjectOfType<DialogueManager>().NextDialogueSentence();
                }
            }
        }
        // Temporary keyboard controls for windows testing
        //if (Input.GetButtonDown("Fire1") && DialogueManager.IsInDialogue)
        //{
        //    FindObjectOfType<DialogueManager>().NextDialogueSentence();
        //}
        //if (Input.GetButtonDown("Jump") && the_joystick.Horizontal == 0 && the_joystick.Vertical == 0)
        //{
        //    BreatheFire();
        //}
        //if (Input.GetButtonUp("Jump"))
        //{
        //    StopFire();
        //}
        //Death Scenarios
        if (gameObject.transform.position.y < y_death_level)
        {
            Die();
        }
        //Animations
        if (is_grounded == false)
        {
            animator.SetBool("is_jumping", true);
        }
        if (is_grounded == true)
        {
            animator.SetBool("is_jumping", false);
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Ground")
        {
            is_grounded = true;
           // Debug.Log("op de grond");
        }
        if (collision.gameObject.tag == "movplat")
        {
            is_grounded = true;
            this.transform.parent = collision.transform;
            Debug.Log("op platform");
            player_speed = 0;
        }
    }
    void OnCollisionExit2D(Collision2D col)
    {
        if (col.gameObject.tag == "movplat")
            this.transform.parent = null;
        player_speed = 10;
    }
    //Kill the player (technically reloading the level)
    public void Die()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    public void StrongJump()
    {
        
    }
    //Make the player jump by adding force upward
    public void Jump()
    {

        if (is_grounded && jump_count == 0)
        {
            is_grounded = false;
            this.gameObject.GetComponent<Rigidbody2D>().AddForce(Vector2.up * normal_jump_power);
            jump_count = jump_count + 1;
            print(jump_count);
            this.gameObject.GetComponent<Rigidbody2D>().AddForce(Vector2.right * 50);

        }
       
    }
    public void Jump2()
    {

        if (jump_count == 1 && is_grounded == false)
        {
            is_grounded = false;
            this.gameObject.GetComponent<Rigidbody2D>().AddForce(Vector2.up * strong_jump_power);
            jump_count = jump_count + 1;
            print(jump_count);
            this.gameObject.GetComponent<Rigidbody2D>().AddForce(Vector2.right * 50);

        }

    }

    void FlipPlayer()
    {
        going_right = !going_right;
        transform.Rotate(0f, 180f, 0f);
    }
    //private void OnCollisionEnter2D(Collision2D collision2d)
    //{



    //    if (collision2d.gameObject.tag == "enemy" && going_right == true)
    //    {
    //        print("osdfoadsfjk");
    //        GetComponent<Rigidbody2D>().AddForce(Vector2.left * (force));


    //    }
    //    if (collision2d.gameObject.tag == "enemy" && going_right == false)
    //    {

    //        GetComponent<Rigidbody2D>().AddForce(Vector2.right * (force));


    //    }


    //}

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Modder")
        {

            player_speed = 10;
        }
    }

    private void OnTriggerEnter2D(Collider2D trig)
    {
        //if (collision.gameObject.tag == "EnemyCollider")
        //{

        //    Flip();
        //    print("FLIP!");
        //}
        if (trig.gameObject.tag == "EnemyCollider")
        {
            print("playercheck");
        }
        if (trig.gameObject.tag == "Modder")
        {
            print("kaas");
            player_speed = 4;
        }

    }
    void Movement()
    {
        horizontal_move = 1;
        gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(horizontal_move * player_speed, gameObject.GetComponent<Rigidbody2D>().velocity.y);

        horizontal_move = the_joystick.Horizontal;
        animator.SetFloat("Speed", Mathf.Abs(horizontal_move));
        if (!DialogueManager.is_in_dialogue)
        {
            if (horizontal_move > 0.0f && going_right == false)
            {
                FlipPlayer();
            }
            if (horizontal_move < 0.0f && going_right == true)
            {
                FlipPlayer();
            }
            //horizontal movement
            
        
                
              
            //float VerticalMove = the_joystick.Vertical;
            //if (the_joystick.Vertical >= 0.5f && is_grounded)
            //{
            //    Jump();
            //}
        }
        //player movement gets reset when he enters dialogue
        if (DialogueManager.is_in_dialogue)
        {
            gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(0, gameObject.GetComponent<Rigidbody2D>().velocity.y);
        }
    }
    public IEnumerator KnockBack(float knockDur, float knockBackPwr, Vector3 knockBackDirection)
    {
        
        float timer = 0;
        while (knockDur > timer)
        {
            timer += Time.deltaTime;
            //<----------------------
            this.gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(this.gameObject.GetComponent<Rigidbody2D>().velocity.x, 0);
            this.gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector3(-knockBackDirection.x, -knockBackDirection.y + knockBackPwr, transform.position.z));
            print("yeet");
            
        }
        yield return 0;

    }
}

        