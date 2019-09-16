using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueTrigger : MonoBehaviour
{
    public Dialogue CurrentDialogue;

    void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            InitiateDialogue();
        }
    }

    public void InitiateDialogue()
    {
        FindObjectOfType<DialogueManager>().StartDialogue(CurrentDialogue);
    }
}