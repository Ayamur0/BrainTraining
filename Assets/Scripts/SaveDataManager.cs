using System;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using UnityEngine;

public class SaveDataManager : MonoBehaviour {
    public static RiddleSaveData RiddleSaveData;

    private static string RiddleSavePath = Application.dataPath + "/Saves/RiddleSaveData.dat";

    public static void SaveGame() {
        BinaryFormatter bf = new BinaryFormatter();
        FileStream file = File.Create(RiddleSavePath);
        bf.Serialize(file, RiddleSaveData);
        file.Close();
        Debug.Log("Game saved");
    }

    public static void LoadGame() {
        if (File.Exists(RiddleSavePath)) {
            BinaryFormatter bf = new BinaryFormatter();
            FileStream file = File.Open(RiddleSavePath, FileMode.Open);
            RiddleSaveData = bf.Deserialize(file) as RiddleSaveData;
            file.Close();
            Debug.Log("Game loaded");
        } else {
            RiddleSaveData = new RiddleSaveData();
            Debug.Log("No saved data, loading default data");
        }
    }

    public static void ResetData() {
        if (File.Exists(RiddleSavePath)) {
            File.Delete(RiddleSavePath);
            RiddleSaveData = new RiddleSaveData();
            Debug.Log("Reset save data");
        }
    }
}
