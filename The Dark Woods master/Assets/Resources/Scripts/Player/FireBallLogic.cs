﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(BoxCollider2D))]
public class FireBallLogic : MonoBehaviour
{
    //Variables
    public float Damage = 10;
    //Unity functions
    public void Update()
    {
        Destroy(this.gameObject, 5);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log(Damage + " inlogic");
        //Code below is executed when the fire prefab this script is attatched to comes in contact with an enemy
        if (collision.gameObject.tag == "enemy")
        {
            collision.GetComponent<HealthComponent>().TakeDamage(this.Damage);
            Debug.Log("Dealing " + this.Damage + " damage");
            Destroy(this.gameObject);
        }
        else if (collision.gameObject.tag != "Attack" && collision.gameObject.tag != "Player" && collision.gameObject.tag != "EnemyCollider" && collision.gameObject.tag != "Untagged")
        {
            Destroy(this.gameObject);
        }
    }
}