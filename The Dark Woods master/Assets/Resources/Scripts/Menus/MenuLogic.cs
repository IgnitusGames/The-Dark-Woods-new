using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuLogic : MonoBehaviour
{
    public void StartButton()
    {
        SaveSystem.CreateDummySave();
        GameManager.game_manager.has_pressed_continue = false;
        SceneManager.LoadScene("Level 1");
    }
    public void ContinueButton()
    {
        GameManager.game_manager.has_pressed_continue = true;
        SceneManager.LoadScene(LevelManager.LoadScene());
    }
}