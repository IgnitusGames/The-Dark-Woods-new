using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public bool has_pressed_continue = false;
    public bool player_needs_respawn = false;

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
