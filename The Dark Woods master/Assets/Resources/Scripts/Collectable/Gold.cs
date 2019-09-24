using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gold : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        RotateLeft();
    }
   

    // Update is called once per frame
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {

            

            FindObjectOfType<AudioManager>().Play("GoldSound");
            collision.gameObject.GetComponent<Player_Health_Collectible>().GoldScore(1);
            Destroy(this.gameObject);


         
        }
    }

    void RotateLeft()
    {
        transform.Rotate(Vector3.forward * Random.Range(-45.0f, 45.0f));
        
    }

}
