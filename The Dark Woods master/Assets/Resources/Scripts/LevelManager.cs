using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    public GameObject player;
    public static Scene next_level;

    float[] player_position;
    int player_health;
    int player_level;
    int gold_score;
    int crystal_score;
    bool has_reached_checkpoint;

    private static LevelManager _Instance;

    public static LevelManager Instance
    {
        get
        {
            return _Instance;
        }
    }

    private SaveData save_data;
    private void Start()
    {
        //load player data
        _Instance = this;
        save_data = SaveSystem.LoadProgress();
        //print(save_data.save_is_checkpoint);
        PlayerLogic player_data = player.GetComponent<PlayerLogic>();

        if (save_data.save_is_checkpoint)
        {
            Vector3 new_player_position = ReconvertPosition(save_data.player_poition);
            player.transform.position = new_player_position;
        }
        if(SceneManager.GetActiveScene().name != "Menu")
        {

        }
    }
    private Vector3 ReconvertPosition(float[] player_pos)
    {
        return new Vector3(player_pos[0], player_pos[1], player_pos[2]);
    }
}