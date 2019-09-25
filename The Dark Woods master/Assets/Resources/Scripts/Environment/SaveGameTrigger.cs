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
            PlayerLogic player_logic = collision.GetComponent<PlayerLogic>();
            Player_Health_Collectible collectables = collision.GetComponent<Player_Health_Collectible>();
            if (is_checkpoint)
            {
                //save game met potitie
                string current_level = SceneManager.GetActiveScene().name;
                SaveData data_to_save = new SaveData(current_level, player_logic.transform.position, collectables.crystal_score, collectables.curHealth, collectables.gold_score, true, get_collected_crystals(), false);
                SaveSystem.SaveProgress(data_to_save);
            }
            else if(!is_checkpoint && collectables.crystal_score == 3)
            {
                string level_to_save = LevelManager.GetNextLevelName();
                SaveData data_to_save = new SaveData(level_to_save, new Vector3(), 0, collectables.curHealth, collectables.gold_score, false, new bool[] {false, false, false }, false);
                SaveSystem.SaveProgress(data_to_save);
                //save game zonder positie
            }
        }
    }
    private bool[] get_collected_crystals()
    {
        bool[] collected_crystals = new bool[3];
        for (int crystal_number = 0; crystal_number < LevelManager.Instance.crystals.Length; crystal_number++)
        {
            GameObject current_crystal = LevelManager.Instance.crystals[crystal_number];
            Crystal crystal_data = current_crystal.GetComponent<Crystal>();
            if (crystal_data.collected)
            {
                collected_crystals[crystal_number] = true;
            }
            else
            {
                collected_crystals[crystal_number] = false;
            }
        }
        return collected_crystals;
    }
    //private int CorrectCrystalScore(int crystal_score)
    //{
    //    if(crystal_score == 0)
    //    {
    //        return 0;
    //    }
    //    else
    //    {
    //        return crystal_score - 1;
    //    }
    //}
}