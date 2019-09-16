using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class HUD : MonoBehaviour
{
    public Sprite[] HeartSprites;

    public Image HeartUI;

    public Player_Health_Collectible player;

    public Sprite[] crystal_sprites;

    public Image crystal;


    

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player_Health_Collectible>();
    }
    private void Update()
    {
        HeartUI.sprite = HeartSprites[player.curHealth];
        crystal.sprite = crystal_sprites[player.crystal_score];

    }
}
