using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class Turret_Bullet : MonoBehaviour
{

    void Update()
    {
        Destroy(this.gameObject, 5);
    }

    void OnTriggerEnter2D(Collider2D trig)
    {
        if (trig.gameObject.tag == "Player")
        {
            FindObjectOfType<AudioManager>().Play("EnemyTurretBulletHit");
            Debug.Log("playergehit");
            trig.GetComponent<Player_Health_Collectible>().Damage(1);
            Destroy(this.gameObject, 1);
        }
    }

}
