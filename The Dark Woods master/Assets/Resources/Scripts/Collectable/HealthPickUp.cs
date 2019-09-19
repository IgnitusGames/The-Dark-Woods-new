using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthPickUp : MonoBehaviour
{
    // Start is called before the first frame update


    void OnTriggerEnter2D(Collider2D trig)
    {
        if (trig.gameObject.tag == "Player")
        {
            FindObjectOfType<AudioManager>().Play("CrystalSound");
            trig.GetComponent<Player_Health_Collectible>().Health(2);
            Destroy(this.gameObject);
        }
    }
}

