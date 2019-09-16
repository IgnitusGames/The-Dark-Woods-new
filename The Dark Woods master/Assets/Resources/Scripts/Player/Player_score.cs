using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class Player_score : MonoBehaviour
{
    public float timeLeft = 120;
    public int playerScore = 0;
   // public GameObject timeLeftUI;
 //   public GameObject playerScoreUI;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        timeLeft -= Time.deltaTime;
        //timeLeftUI.gameObject.GetComponent<Text>().text = ("Time Left: " + (int)timeLeft);
  //      playerScoreUI.gameObject.GetComponent<Text>().text = ("Score: " + (int)playerScore);


        if (timeLeft < 0.1)
        {
            SceneManager.LoadScene("Prototype_1");
        }
           
    }
    void OnTriggerEnter2D(Collider2D trig)
    {
        if (trig.gameObject.name == "Endlevel")
        {
            CountScore();
            Debug.Log("in endlevel zone");
        }
        if (trig.gameObject.tag == "collectable")
        {

            Debug.Log("iwoaoa");
            playerScore += 10;
        }

    }
    void CountScore()
    {
        playerScore = playerScore + (int)(timeLeft * 10);
       

    }
}
