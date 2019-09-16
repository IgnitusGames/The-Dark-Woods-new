using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class Turret_Bullet : MonoBehaviour
{

    void OnTriggerEnter2D(Collider2D trig)
    {
        if (trig.gameObject.tag == "Player")
        {

            Debug.Log("playergehit");
            trig.GetComponent<Player_Health_Collectible>().Damage(1);
        }
    }

}
