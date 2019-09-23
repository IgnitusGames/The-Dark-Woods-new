using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Dialogue
{
    public string dialogue_name;

    [TextArea(3, 10)]
    public string[] sentences;
}
[System.Serializable]
public class SaveData
{
    string world_level;
    float[] player_poition;
    int crystal_score;
    int player_level;
    int player_health;
    int gold_score;
    bool player_has_reached_checkpoint;
    public SaveData(GameManager game_state, string level_name)
    {
        this.world_level = level_name;
        this.player_poition = ConvertPosition(game_state.player_position);
        this.crystal_score = game_state.crystal_score;
        this.player_level = game_state.player_level;
        this.player_health = game_state.player_health;
        this.gold_score = game_state.gold_score;
        this.player_has_reached_checkpoint = game_state.player_has_reached_checkpoint;
    }
    private float[] ConvertPosition(Vector3 player_position)
    {
        float[] converted_position = new float[3];
        converted_position[0] = player_position.x;
        converted_position[1] = player_position.y;
        converted_position[2] = player_position.z;
        return converted_position;
    }
}