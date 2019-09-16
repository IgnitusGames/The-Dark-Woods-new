using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Crystal : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }
    // Update is called once per frame
    void Update()
    {
        
    }
    void OnTriggerEnter2D(Collider2D trig)
    {
        if (trig.gameObject.tag == "Player")
        {
            Debug.Log("player raakt aan");
            trig.GetComponent<Player_Health_Collectible>().CrystalScore(1);
            Destroy(this.gameObject);
        }
    }
}