using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turret_Bullet : MonoBehaviour
{
    private Player_Health_Collectible player;
    void Update()
    {
        Destroy(this.gameObject, 5);
    }
    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player_Health_Collectible>();

    }
    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("Player"))
        {
            FindObjectOfType<AudioManager>().Play("EnemyTurretBulletHit");

            player.Damage(1);
            Destroy(this.gameObject, 1);
        }
    }
}