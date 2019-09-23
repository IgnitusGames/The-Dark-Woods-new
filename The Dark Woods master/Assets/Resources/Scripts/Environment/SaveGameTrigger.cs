using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SaveGameTrigger : MonoBehaviour
{
    public bool is_checkpoint = true;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            Debug.Log("Saving game");
            if(is_checkpoint)
            {
                //save game met potitie
                PlayerLogic player_logic = collision.GetComponent<PlayerLogic>();
                Player_Health_Collectible collectables = collision.GetComponent<Player_Health_Collectible>();
                string current_level = SceneManager.GetActiveScene().name;
                SaveData data_to_save = new SaveData(current_level, player_logic.transform.position, collectables.crystal_score, player_logic.player_curr_health, collectables.gold_score, true);
                SaveSystem.SaveProgress(data_to_save);
            }
            else
            {
                PlayerLogic player_logic = collision.GetComponent<PlayerLogic>();
                Player_Health_Collectible collectables = collision.GetComponent<Player_Health_Collectible>();
                string level_to_save = LevelManager.next_level.name;
                SaveData data_to_save = new SaveData(level_to_save, new Vector3(), collectables.crystal_score, player_logic.player_curr_health, collectables.gold_score, false);
                SaveSystem.SaveProgress(data_to_save);
                //save game zonder positie
            }
        }
    }
}