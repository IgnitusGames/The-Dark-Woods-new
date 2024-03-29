﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerCombat : MonoBehaviour
{
    //Variables
    public GameObject fire;
    public GameObject fire_ball;
    public GameObject fire_point;
    public float fire_damage_breath = 1 ;
    public float fire_damage_ball = 3;
    public float fire_speed;
    public Animator animator;
    private GameObject fire_instance;
    public bool is_fireing;
    AudioSource fire_breath_audio;
    AudioSource errorAudio;
    AudioSource fire_ball_audio;
    private Player_Health_Collectible player;

    public float modifier = 1;
    public float dmg_increase;


    // Start is called before the first frame update
    void Start()
    {
        is_fireing = false;
        fire_instance = null;
        AudioSource[] audios = GetComponents<AudioSource>();
        errorAudio = audios[0];
        fire_breath_audio = audios[1];
        fire_ball_audio = audios[2];
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player_Health_Collectible>();
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
    public void Upgrade()
    {
        modifier = player.gold_score / 100;
        fire_damage_breath += modifier;
        fire_damage_ball += modifier;
        Debug.Log(modifier);

        //fire_damage = fire_damage + modifier;
    }
    //custom functions
    //instantiate fire attack
    public void BreatheFire()
    {
        if (!is_fireing)
        {
            is_fireing = true;
            fire_breath_audio.Play();
            animator.SetBool("is_fireing", true);
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
            fire_instance.GetComponent<FireLogic>().Damage = fire_damage_breath;
            Debug.Log(fire_damage_breath);
        }     
    }
    public void FireBallAtack()
    {
        animator.SetBool("is_fireing", true);
        if (fire_point.transform.position.x < this.transform.position.x)
        {
            GameObject fire_ball_instance;
            fire_ball_instance = Instantiate(fire_ball, fire_point.transform.position, Quaternion.Euler(fire_point.transform.rotation.x, 180, fire_point.transform.rotation.z)) as GameObject;
            fire_ball_instance.GetComponent<Rigidbody2D>().velocity = new Vector2(-1, 0) * fire_speed;
           // Debug.Log("bal links");
            fire_ball_audio.Play();
            fire_ball_instance.GetComponent<FireBallLogic>().Damage = fire_damage_ball;
        }
        else if (fire_point.transform.position.x > this.transform.position.x)
        { 
            GameObject fire_ball_instance;
            fire_ball_instance = Instantiate(fire_ball, fire_point.transform.position, Quaternion.identity) as GameObject;
            fire_ball_instance.GetComponent<Rigidbody2D>().velocity = new Vector2(1, 0) * fire_speed;
          //  Debug.Log("bal rechts");
            fire_ball_audio.Play();
            fire_ball_instance.GetComponent<FireBallLogic>().Damage = fire_damage_ball;
        }
        Debug.Log(fire_damage_ball);
        StartCoroutine(FireBallWait());
    }
    //Remove fire attack from the scene
    public void StopFire()
    {
        is_fireing = false;
        animator.SetBool("is_fireing", false);
        fire_breath_audio.Stop();
        Destroy(fire_instance);
    }
    IEnumerator FireBallWait()
    {
        yield return new WaitForSeconds(0.1f);
        animator.SetBool("is_fireing", false);
    }
}