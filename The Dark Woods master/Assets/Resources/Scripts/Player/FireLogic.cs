using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(BoxCollider2D))]
public class FireLogic : MonoBehaviour
{
    //Variables
    public int Damage;
    //Unity functions
    private void OnTriggerEnter2D(Collider2D collision)
    {
        //Code below is executed when the fire prefab this script is attatched to comes in contact with an enemy
        if(collision.gameObject.tag == "enemy")
        {
            Destroy(collision.gameObject); //Kills the enemy the fire has collided with
            Debug.Log("Dealing " + Damage + " damage");
        }
    }
}