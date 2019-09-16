using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class Player_health : MonoBehaviour
{


    public int curHealth;
    public int maxHealth = 5;
    public int damage;
    public bool hasDied;
    public int crystal_score;
    

    // Start is called before the first frame update
    void Start()
    {
        hasDied = false;
        curHealth = maxHealth;

    }

    // Update is called once per frame
    void Update()
    {
        if (gameObject.transform.position.y < -7)
        {
            Debug.Log("has died");
            Die();
            print(crystal_score);

        }
        //if (health < 1)
        //{
        //    Debug.Log("teveel dmg");
        //    Die();
        //}
        if (curHealth > maxHealth)
        {
            curHealth = maxHealth;
        }
        if(curHealth <= 0)
        {
            Die();

        }
        
    }
    public void Die()
    {



        SceneManager.LoadScene("Prototype_1");
   
    }
    public void Damage(int dmg)
    {
        curHealth -= dmg;
    }
    public void CrystalScore(int crystalscore)
    {
        crystal_score += crystalscore;
        print(crystal_score);
    }
}
