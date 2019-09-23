using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

public static class SaveSystem
{
    public static void SaveProgress(SaveData data_to_save)
    {
        BinaryFormatter formatter = new BinaryFormatter();
        string save_path = Application.persistentDataPath + "/the_dark_woods.save";
        FileStream file_stream = new FileStream(save_path, FileMode.Create);
        formatter.Serialize(file_stream, data_to_save);
        file_stream.Close();
    }
    public static SaveData LoadProgress()
    {
        string save_path = Application.persistentDataPath + "/the_dark_woods.save";
        if(File.Exists(save_path))
        {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream file_stream = new FileStream(save_path, FileMode.Open);
            SaveData saved_data = formatter.Deserialize(file_stream) as SaveData;
            file_stream.Close();
            Debug.Log(save_path);
            return saved_data;
        }
        else
        //create empty save file if one does not exist
        {
            //Debug.LogError("Missing save file");
            Debug.Log("Creating empty save file");
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream file_stream = new FileStream(save_path, FileMode.Create);
            formatter.Serialize(file_stream, "");
            file_stream.Close();
            return null;
        }
    }
}
