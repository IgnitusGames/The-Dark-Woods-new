﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class Player_Health_Collectible : MonoBehaviour
{
    public int curHealth;
    public int maxHealth = 10;
    public int damage;
    public bool hasDied;
    public int crystal_score;
    public int gold_score = 0;
    public float force = 1000;

    private PlayerCombat player_combat;



    void Start()
    {
        hasDied = false;
        curHealth = maxHealth;
        player_combat = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerCombat>();

    }
   
    void Update()
    {
 
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
        GameManager.game_manager.player_needs_respawn = true;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    public void Damage(int dmg)
    {
        curHealth -= dmg;
        FindObjectOfType<AudioManager>().Play("PlayerDmg");
        gameObject.GetComponent<Animation>().Play("player_dmg");
    }
    public void Health(int dmg)
    {
        int new_health = curHealth += dmg;
        if(new_health > maxHealth)
        {
            new_health = maxHealth;
        }
        curHealth = new_health;
    }

    public void CrystalScore(int crystalscore)
    {
        crystal_score += crystalscore;
        print(crystal_score);
    }
    public void GoldScore(int goldscore)
    {
        gold_score += goldscore;
        //print(gold_score);
        player_combat.Upgrade();
    }
   
}

