using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Health : MonoBehaviour
{
    public int enemy_curr_health;
    public int enemy_max_health;


    // Update is called once per frame
    void Update()
    {
       if (gameObject.transform.position.y <-10 || enemy_curr_health <= 0)
        {
            Destroy(gameObject);
        }
        if (enemy_curr_health > enemy_max_health)
        {
            enemy_curr_health = enemy_max_health;
        }


    }
    public void EnemyDamage(int enemydmg)
    {
        enemy_curr_health -= enemydmg;
    }
}
