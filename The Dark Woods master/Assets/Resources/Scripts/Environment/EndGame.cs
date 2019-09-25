using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndGame : MonoBehaviour
{
    public Dialogue current_dialogue;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            if(collision.GetComponent<Player_Health_Collectible>().crystal_score == 3)
            {
                //SceneManager.LoadScene("EndScreen");
                collision.GetComponent<Player_Health_Collectible>().crystal_score = 0;
                SceneManager.LoadScene(LevelManager.GetNextLevelName());
            }
            else
            {
                InitiateDialogue();
            }
        }
    }
    public void InitiateDialogue()
    {
        FindObjectOfType<DialogueManager>().StartDialogue(current_dialogue);
    }
}
