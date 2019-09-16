using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour
{
    // Variables
    public static bool is_in_dialogue = false;
    public Text dialogue_name;
    public Text dialogue_content;
    public Animator dialogue_animator;

    private Queue<string> AllSentences;
    // Start is called before the first frame update
    void Start()
    {
        AllSentences = new Queue<string>();
    }
    public void StartDialogue(Dialogue CurrentDialogue)
    {
        is_in_dialogue = true;
        dialogue_animator.SetBool("IsOpen", true);
        dialogue_name.text = CurrentDialogue.dialogue_name;
        AllSentences.Clear();
        foreach(string sentence in CurrentDialogue.sentences)
        {
            AllSentences.Enqueue(sentence);
        }
        NextDialogueSentence();
    }
    public void NextDialogueSentence()
    {
        if(AllSentences.Count == 0)
        {
            EndDialogue();
            return;
        }
        else
        {
            string CurrentSentence = AllSentences.Dequeue();
            StopAllCoroutines();
            StartCoroutine(TypeSentence(CurrentSentence));
        }
    }
    void EndDialogue()
    {
        is_in_dialogue = false;
        dialogue_animator.SetBool("IsOpen", false);
    }
    IEnumerator TypeSentence(string Sentence)
    {
        dialogue_content.text = "";
        foreach(char letter in Sentence)
        {
            dialogue_content.text += letter;
            yield return null;
        }
    }
}