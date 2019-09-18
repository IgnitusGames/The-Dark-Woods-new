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
    public int jump_power = 35;
    public int player_max_health;
    public int player_curr_health;
    public int player_mana;
    public int y_death_level;
    public float ray_origin_y;
    public float hit_distance;
    public bool is_grounded = true;
    public bool jump;
    public float force = 100;

    private float horizontal_move;
    public bool going_right = true;
    // Update is called once per frame
    void Update()
    {
        Movement();
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
            Debug.Log("op de grond");
        }
    }
    //Kill the player (technically reloading the level)
    public void Die()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    //Make the player jump by adding force upward
    public void Jump()
    {
        if(is_grounded)
        {
            is_grounded = false;
            this.gameObject.GetComponent<Rigidbody2D>().AddForce(Vector2.up * jump_power);
        }
        //jump = true;
    }
    //void PlayerRaycast()
    //{
    //    RaycastHit2D rayDown = Physics2D.Raycast(new Vector2(transform.position.x, transform.position.y), Vector2.down); //create downward raycast
    //    //test if the downward ray is short enough to consider the player grounded
    //    Debug.DrawRay(new Vector3(rayDown.centroid.x, rayDown.centroid.y, transform.position.z), new Vector3(rayDown.point.x, rayDown.point.y, transform.position.z));
    //    if (rayDown != null && rayDown.collider != null && rayDown.distance <= 0 && rayDown.collider.tag != "Enemy")
    //    {
    //        is_grounded = true;         
    //    }
    //}
    //Turn the player gamne object (and children)
    void FlipPlayer()
    {
        going_right = !going_right;
        transform.Rotate(0f, 180f, 0f);
    }
    private void OnCollisionEnter2D(Collision2D collision2d)
    {



        if (collision2d.gameObject.tag == "enemy" && going_right == true)
        {
            print("osdfoadsfjk");
            GetComponent<Rigidbody2D>().AddForce(Vector2.left * (force));


        }
        if (collision2d.gameObject.tag == "enemy" && going_right == false)
        {

            GetComponent<Rigidbody2D>().AddForce(Vector2.right * (force));


        }


    }
    void Movement()
    {
        float horizontal_move = the_joystick.Horizontal;
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
            if (the_joystick.Horizontal >= 0.2f || the_joystick.Horizontal <= -0.2f)
            {
                gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(horizontal_move * player_speed, gameObject.GetComponent<Rigidbody2D>().velocity.y);
            }
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
}