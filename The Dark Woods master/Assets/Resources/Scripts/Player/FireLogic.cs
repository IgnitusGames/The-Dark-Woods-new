using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(BoxCollider2D))]
public class FireLogic : MonoBehaviour
{
    //Variables
    public int Damage;
    // Start is called before the first frame update
    void Start()
    {
        
    }
    // Update is called once per frame
    void Update()
    {

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "enemy")
        {
            Destroy(collision.gameObject);
            Debug.Log("Dealing " + Damage + " damage");
        }
    }
}