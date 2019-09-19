using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(BoxCollider2D))]
public class FireBallLogic : MonoBehaviour
{
    //Variables
    public int Damage = 5;
    //Unity functions
    public void Update()
    {
        Destroy(this.gameObject, 5);
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        //Code below is executed when the fire prefab this script is attatched to comes in contact with an enemy
        if (collision.gameObject.tag == "enemy")
        {
            collision.GetComponent<Enemy_Health>().EnemyDamage(1);
            Debug.Log("Dealing " + Damage + " damage");
        }
        else if(collision.gameObject.tag != "Attack")
        {
            Destroy(this.gameObject);
        }
    }
}