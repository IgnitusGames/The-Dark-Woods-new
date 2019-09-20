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
public class SaveData
{
    string world_level;
    float[] player_poition;
    int player_level;
    int gold_score;
    public SaveData()
    {

    }
}