using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuLogic : MonoBehaviour
{
    public void StartButton()
    {
        SceneManager.LoadScene("TutorialLevel");
    }
    public void ContinueButton()
    {
        Debug.Log("Proper continue fonctionality to be implemented");
        SceneManager.LoadScene("TutorialLevel");
    }
}