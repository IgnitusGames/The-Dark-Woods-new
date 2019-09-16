using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour
{
    // Variables
    public static bool IsInDialogue = false;
    public Text DialogueName;
    public Text DialogueContent;
    public Animator DialogueAnimator;

    private Queue<string> AllSentences;
    // Start is called before the first frame update
    void Start()
    {
        AllSentences = new Queue<string>();
    }
    public void StartDialogue(Dialogue CurrentDialogue)
    {
        IsInDialogue = true;
        DialogueAnimator.SetBool("IsOpen", true);
        DialogueName.text = CurrentDialogue.DialogueName;
        AllSentences.Clear();
        foreach(string sentence in CurrentDialogue.Sentences)
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
        IsInDialogue = false;
        DialogueAnimator.SetBool("IsOpen", false);
    }
    IEnumerator TypeSentence(string Sentence)
    {
        DialogueContent.text = "";
        foreach(char letter in Sentence)
        {
            DialogueContent.text += letter;
            yield return null;
        }
    }
}