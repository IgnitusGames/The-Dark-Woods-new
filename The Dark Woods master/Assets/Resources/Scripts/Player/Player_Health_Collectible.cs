using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player_Health_Collectible : MonoBehaviour
{


    public int curHealth;
    public int maxHealth = 10;
    public int damage;
    public bool hasDied;
    public int crystal_score;
    public float force = 1000;
    


    // Start is called before the first frame update
    void Start()
    {
        hasDied = false;
        curHealth = maxHealth;

    }

    // Update is called once per frame
    void Update()
    {
      
        //if (health < 1)
        //{
        //    Debug.Log("teveel dmg");
        //    Die();
        //}
        if (curHealth > maxHealth)
        {
            curHealth = maxHealth;
        }
        if (curHealth <= 0)
        {
            Die();

        }

    }
    public void Die()
    {



       SceneManager.LoadScene(SceneManager.GetActiveScene().name);

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

