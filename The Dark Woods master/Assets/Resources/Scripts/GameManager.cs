using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public bool has_pressed_continue = true;

    public static GameManager game_manager { get; private set; }
    private void Awake()
    {
        if (game_manager == null)
        {
            game_manager = this;
            DontDestroyOnLoad(this.gameObject);
        }
        else
        {
            Destroy(this.gameObject);
        }
    }
}
