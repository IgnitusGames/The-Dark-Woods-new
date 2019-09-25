using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthPickUp : MonoBehaviour
{
    // Start is called before the first frame update

    public int heal_amount = 2;
    void OnTriggerEnter2D(Collider2D trig)
    {
        if (trig.gameObject.tag == "Player" && trig.gameObject.GetComponent<Player_Health_Collectible>().curHealth < trig.gameObject.GetComponent<Player_Health_Collectible>().maxHealth)
        {
            FindObjectOfType<AudioManager>().Play("HealthPickUp");
            trig.GetComponent<Player_Health_Collectible>().Health(heal_amount);
            Destroy(this.gameObject);
        }
    }
}

