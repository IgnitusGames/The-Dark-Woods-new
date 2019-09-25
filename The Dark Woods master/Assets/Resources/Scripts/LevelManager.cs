using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    public GameObject player;
    public GameObject[] crystals;
    [TextArea(1,1)]
    [SerializeField] private string next_level;

    //float[] player_position;
    //int player_health;
    //int player_level;
    //int gold_score;
    //int crystal_score;
    //bool has_reached_checkpoint;

    private static LevelManager _Instance;

    public static LevelManager Instance
    {
        get
        {
            return _Instance;
        }
    }

    private SaveData save_data;
    private PlayerLogic player_data;
    private Player_Health_Collectible collectables;
    private void Start()
    {
        _Instance = this;
        save_data = SaveSystem.LoadProgress();
        if (player != null)
        {
            player_data = player.GetComponent<PlayerLogic>();
            collectables = player.GetComponent<Player_Health_Collectible>();
        }
        LoadLevel();
    }
    private Vector3 ReconvertPosition(float[] player_pos)
    {
        return new Vector3(player_pos[0], player_pos[1], player_pos[2]);
    }
    public void LoadLevel()
    {
        if(GameManager.game_manager.has_pressed_continue)
        {
            if (save_data.is_dummy_save)
            {
                return;
            }
            else
            {
                if(player != null)
                {
                    if(save_data.save_is_checkpoint)
                    {
                        player.transform.position = ReconvertPosition(save_data.player_poition);
                        collectables.crystal_score = save_data.crystal_score;
                        player_data.player_curr_health = save_data.player_health;
                        collectables.gold_score = save_data.gold_score;
                    }
                    else
                    {
                        collectables.crystal_score = save_data.crystal_score;
                        player_data.player_curr_health = save_data.player_health;
                        collectables.gold_score = save_data.gold_score;
                    }
                }
                for(int crystal_number = 0; crystal_number < crystals.Length; crystal_number++)
                {
                    GameObject current_crystal = crystals[crystal_number];
                    Crystal crystal_data = current_crystal.GetComponent<Crystal>();
                    crystal_data.collected = save_data.collected_crystals[crystal_number];
                    if(crystal_data.collected)
                    {
                        current_crystal.SetActive(false);
                    }
                }
            }
        }
        else
        {
            if (GameManager.game_manager.player_needs_respawn && save_data.save_is_checkpoint)
            {
                player.transform.position = ReconvertPosition(save_data.player_poition);
                collectables.crystal_score = save_data.crystal_score;
                player_data.player_curr_health = save_data.player_health;
                collectables.gold_score = save_data.gold_score;
                GameManager.game_manager.player_needs_respawn = false;
                for (int crystal_number = 0; crystal_number < crystals.Length; crystal_number++)
                {
                    GameObject current_crystal = crystals[crystal_number];
                    Crystal crystal_data = current_crystal.GetComponent<Crystal>();
                    crystal_data.collected = save_data.collected_crystals[crystal_number];
                    if (crystal_data.collected)
                    {
                        current_crystal.SetActive(false);
                    }
                }
            }
            else
            {
                collectables.crystal_score = save_data.crystal_score;
                player_data.player_curr_health = save_data.player_health;
                collectables.gold_score = save_data.gold_score;
            }
        }
    }
    public static string LoadScene()
    {
        if(Instance.save_data.is_dummy_save)
        {
            return "Level 1";
        }
        else
        {
            return Instance.save_data.world_level;
        }
    }
    public static string GetNextLevelName()
    {
        return Instance.next_level;
    }
}