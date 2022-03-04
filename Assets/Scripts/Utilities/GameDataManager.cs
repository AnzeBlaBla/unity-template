using UnityEngine;
using System.IO;
using Newtonsoft.Json;

// TODO: maybe encrypt data before saving and decrypt data after loading
static class GameDataManager
{
    private static void SaveGameData(string fileName, string data)
    {
        string path = Application.persistentDataPath + "/" + fileName;
        //Debug.Log("Saving data to " + path);
        File.WriteAllText(path, data);
    }
    private static string LoadGameData(string fileName)
    {
        string path = Application.persistentDataPath + "/" + fileName;
        if (File.Exists(path))
        {
            return File.ReadAllText(path);
        }
        else
        {
            return "";
        }
    }

    public static void SaveData(string fileName, object data)
    {
        string json = JsonConvert.SerializeObject(data);
        SaveGameData(fileName, json);
    }
    public static T LoadData<T>(string fileName, T defaultData = default(T))
    {
        string json = LoadGameData(fileName);
        if (json == "")
        {
            return defaultData;
        }
        else
        {
            return JsonConvert.DeserializeObject<T>(json);
        }
    }
    public static void DeleteData(string fileName)
    {
        string path = Application.persistentDataPath + "/" + fileName;
        if (File.Exists(path))
        {
            File.Delete(path);
        }
    }
    public static bool DataExists(string fileName)
    {
        string path = Application.persistentDataPath + "/" + fileName;
        return File.Exists(path);
    }

}