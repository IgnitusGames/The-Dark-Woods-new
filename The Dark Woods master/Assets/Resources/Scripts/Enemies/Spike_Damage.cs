using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spike_Damage : MonoBehaviour
{
       private PlayerLogic player;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerLogic>();

    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player"))
        {
            collision.gameObject.GetComponent<Player_Health_Collectible>().Damage(1);
            player.StartCoroutine(player.KnockBack(0.02f, 350, player.transform.position));

        }
    }
}