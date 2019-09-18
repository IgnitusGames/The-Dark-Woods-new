﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Turret_AI_AttackCone : MonoBehaviour
{
    // Start is called before the first frame update
    public Turret_Ai turretAI;
    public bool isLeft = false;


    private void Awake()
    {
        turretAI = gameObject.GetComponentInParent<Turret_Ai>();

    }


    void OnTriggerStay2D(Collider2D trig)
    {
        if (trig.gameObject.tag == "Player")
        {

            turretAI.Attack(true);

        }
        else
        {
            turretAI.Attack(false);

        }
    }

}

    
       