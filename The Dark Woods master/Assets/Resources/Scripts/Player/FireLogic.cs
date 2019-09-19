using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(BoxCollider2D))]
public class FireLogic : MonoBehaviour
{
    //Variables
    public int Damage =1;


    //Unity functions

    public void Update()
    {
        
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        //Code below is executed when the fire prefab this script is attatched to comes in contact with an enemy
        if(collision.gameObject.tag == "enemy")
        {
            collision.GetComponent<Enemy_Health>().EnemyDamage(Damage);
            Debug.Log("Dealing " + Damage + " damage");
          
        }
    }
}