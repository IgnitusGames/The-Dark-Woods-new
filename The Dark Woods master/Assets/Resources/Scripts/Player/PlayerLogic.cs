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
    public GameObject Fire;
    public Joystick TheJoystick;
    public GameObject FirePoint;
    //public float FireRange;
    //public float FireSpread;
    public int PlayerSpeed = 10;
    public int JumpPower = 35;
    public float RayOriginY;
    public float HitDistance;
    public bool IsGrounded = true;
    public int FireDamage;
    public int player_max_health;
    public int player_curr_health;
    public int player_mana;

    private float HorizontalMove;
    private bool GoingRight = true;
    private bool IsFireing;
    private GameObject FireInstance;
    public bool jump;
    // Start is called before the first frame update
    void Start()
    {
        IsFireing = false;
        FireInstance = null;
    }
    // Update is called once per frame
    void Update()
    {

        Movement();
        PlayerRaycast();
       
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
            if (DialogueManager.IsInDialogue)
            {
                if(Input.GetTouch(0).phase == TouchPhase.Ended)
                {
                    FindObjectOfType<DialogueManager>().NextDialogueSentence();
                }
            }
            else
            {
                if (Input.touchCount == 1)
                {
                    if (TheJoystick.Horizontal == 0 && TheJoystick.Vertical == 0 && !PauseLogic.IsPaused)
                    {
                        BreatheFire();
                    }
                    if (Input.GetTouch(0).phase == TouchPhase.Ended)
                    {
                        StopFire();
                    }
                }
                if (Input.touchCount > 1)
                {
                    BreatheFire();
                    if (Input.GetTouch(1).phase == TouchPhase.Ended)
                    {
                        StopFire();
                    }
                }
            }
        }
        // Temporary keyboard controls for windows testing
        //if (Input.GetButtonDown("Fire1") && DialogueManager.IsInDialogue)
        //{
        //    FindObjectOfType<DialogueManager>().NextDialogueSentence();
        //}
        if (Input.GetButtonDown("Jump") && TheJoystick.Horizontal == 0 && TheJoystick.Vertical == 0)
        {
            BreatheFire();
        }
        if (Input.GetButtonUp("Jump"))
        {
            StopFire();
        }
        //Death Scenarios
        if (gameObject.transform.position.y < -20)
        {
            Die();
        }


        if (IsGrounded == false)
        {
            animator.SetBool("is_jumping", true);
        }
        if (IsGrounded == true)
        {
            animator.SetBool("is_jumping", false);
        }



    }
    void BreatheFire()
    {
        if(!IsFireing)
        {
            IsFireing = true;
            if(FirePoint.transform.position.x < this.transform.position.x)
            {
                FireInstance = Instantiate(Fire, new Vector3(this.FirePoint.transform.position.x - (Fire.GetComponent<Renderer>().bounds.size.x/2), this.FirePoint.transform.position.y, this.FirePoint.transform.position.z), Quaternion.Euler(this.FirePoint.transform.rotation.x, this.FirePoint.transform.rotation.y, this.FirePoint.transform.rotation.z + 180));
            }
            else if (FirePoint.transform.position.x > this.transform.position.x)
            {
                FireInstance = Instantiate(Fire, new Vector3(this.FirePoint.transform.position.x + (Fire.GetComponent<Renderer>().bounds.size.x / 2), this.FirePoint.transform.position.y, this.FirePoint.transform.position.z), Quaternion.Euler(this.FirePoint.transform.rotation.x, this.FirePoint.transform.rotation.y, this.FirePoint.transform.rotation.z));
            }
            FireInstance.transform.SetParent(FirePoint.transform);
            //FireInstance.transform.localScale = new Vector3(FireSpread, FireRange, FireInstance.transform.localScale.z);
            FireInstance.GetComponent<FireLogic>().Damage = FireDamage;
        }
    }
    void StopFire()
    {
        IsFireing = false;
        Destroy(FireInstance);
    }
    public void Die()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    void Jump()
    {
        gameObject.GetComponent<Rigidbody2D>().AddForce(Vector2.up * JumpPower);
        IsGrounded = false;
        
        //jump = true;
    }
    void PlayerRaycast()
    {
        RaycastHit2D rayDown = Physics2D.Raycast(new Vector2(transform.position.x, transform.position.y + RayOriginY), Vector2.down);
        
        if (rayDown != null && rayDown.collider != null && rayDown.distance < HitDistance && rayDown.collider.tag != "Enemy")
        {
            IsGrounded = true;
            
        }
    }
    void FlipPlayer()
    {
        Debug.log("yeet");
        GoingRight = !GoingRight;
        transform.Rotate(0f, 180f, 0f);
    }
    void Movement()
    {
        
        float HorizontalMove = TheJoystick.Horizontal;
        
        animator.SetFloat("Speed", Mathf.Abs(HorizontalMove));
        if (!DialogueManager.IsInDialogue)
        {
            if (HorizontalMove > 0.0f && GoingRight == false)
            {
                FlipPlayer();
            }
            if (HorizontalMove < 0.0f && GoingRight == true)
            {
                FlipPlayer();
            }
            if (TheJoystick.Horizontal >= 0.2f || TheJoystick.Horizontal <= -0.2f)
            {
                gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(HorizontalMove * PlayerSpeed, gameObject.GetComponent<Rigidbody2D>().velocity.y);
                print("lopend");
            }
            float VerticalMove = TheJoystick.Vertical;
            if (TheJoystick.Vertical >= 0.5f && IsGrounded)
            {
                Jump();
            }
        }
        if (DialogueManager.IsInDialogue)
        {
            gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(0, gameObject.GetComponent<Rigidbody2D>().velocity.y);
        }
    }
}