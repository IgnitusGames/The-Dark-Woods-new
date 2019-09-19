using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCombat : MonoBehaviour
{
    //Variables
    public GameObject fire;
    public GameObject fire_ball;
    public Joystick the_joystick;
    public GameObject fire_point;
    public int fire_damage;
    public int fire_speed;

    private GameObject fire_instance;
    private bool is_fireing;

    // Start is called before the first frame update
    void Start()
    {
        is_fireing = false;
        fire_instance = null;
    }
    // Update is called once per frame
    void Update()
    {
        //if(Input.touchCount > 0)
        //{
        //    if (!DialogueManager.is_in_dialogue)
        //    {
        //        if (Input.touchCount == 1)
        //        {
        //            if (the_joystick.Horizontal == 0 && the_joystick.Vertical == 0 && !PauseLogic.IsPaused)
        //            {
        //                BreatheFire();
        //            }
        //            if (Input.GetTouch(0).phase == TouchPhase.Ended)
        //            {
        //                StopFire();
        //            }
        //        }
        //        if (Input.touchCount > 1)
        //        {
        //            BreatheFire();
        //            if (Input.GetTouch(1).phase == TouchPhase.Ended)
        //            {
        //                StopFire();
        //            }
        //        }
        //    }
        //}
    }
    //custom functions
    //instantiate fire attack
    public void BreatheFire()
    {
        if (!is_fireing)
        {
            is_fireing = true;
            if (fire_point.transform.position.x < this.transform.position.x)
            {
                fire_instance = Instantiate(fire, new Vector3(this.fire_point.transform.position.x - (fire.GetComponent<Renderer>().bounds.size.x / 2), this.fire_point.transform.position.y, this.fire_point.transform.position.z), Quaternion.Euler(this.fire_point.transform.rotation.x, this.fire_point.transform.rotation.y, this.fire_point.transform.rotation.z + 180));
                FindObjectOfType<AudioManager>().Play("PlayerFire");
            }
            else if (fire_point.transform.position.x > this.transform.position.x)
            {
                fire_instance = Instantiate(fire, new Vector3(this.fire_point.transform.position.x + (fire.GetComponent<Renderer>().bounds.size.x / 2), this.fire_point.transform.position.y, this.fire_point.transform.position.z), Quaternion.Euler(this.fire_point.transform.rotation.x, this.fire_point.transform.rotation.y, this.fire_point.transform.rotation.z));
                FindObjectOfType<AudioManager>().Play("PlayerFire");
            }
            fire_instance.transform.SetParent(fire_point.transform);
            fire_instance.GetComponent<FireLogic>().Damage = fire_damage;
            


        }
    }
    public void FireBallAtack()
    {
        if (fire_point.transform.position.x < this.transform.position.x)
        {
            GameObject fire_ball_instance;
            fire_ball_instance = Instantiate(fire_ball, fire_point.transform.position, Quaternion.Euler(this.fire_point.transform.rotation.x, this.fire_point.transform.rotation.y, this.fire_point.transform.rotation.z + 180)) as GameObject;
            fire_ball_instance = Instantiate(fire_ball) as GameObject;
            fire_ball_instance.transform.SetParent(fire_point.transform);
            fire_ball_instance.GetComponent<Rigidbody2D>().velocity = new Vector2(1, 0) * fire_speed;
            Debug.Log("bal links");
        }
        else if (fire_point.transform.position.x > this.transform.position.x)
        {
            GameObject fire_ball_instance;
            fire_ball_instance = Instantiate(fire_ball) as GameObject;
            fire_ball_instance.transform.SetParent(fire_point.transform);
            fire_ball_instance.GetComponent<Rigidbody2D>().velocity = new Vector2(1, 0) * fire_speed;
            Debug.Log("bal rechts");
        }
    }
    //Remove fire attack from the scene
    public void StopFire()
    {
        is_fireing = false;
        Destroy(fire_instance);
    }
}