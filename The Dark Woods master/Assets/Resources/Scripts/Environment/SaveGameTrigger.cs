using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveGameTrigger : MonoBehaviour
{
    public bool is_checkpoint = true;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            if(is_checkpoint)
            {
                //save game met positie
            }
            else
            {
                //save game zonder positie
            }
        }
    }
}