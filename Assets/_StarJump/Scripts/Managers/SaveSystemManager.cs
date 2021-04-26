using System.IO;
using UnityEngine;

namespace _StarJump.Scripts.Managers
{
    public static class SaveSystemManager
    {
        private static string SAVE_FOLDER = Application.persistentDataPath + "/Saves/";

        public static SaveData Data { get; private set; }
    
        public static string filename = "SaveGameData.json";

        public static void SaveGame()
        {
            string json = JsonUtility.ToJson(Data);
            File.WriteAllText(SAVE_FOLDER + filename, json);
        }

        public static SaveData LoadScoreData()
        {
            if (!Directory.Exists(SAVE_FOLDER))
            {
                //create save folder
                Directory.CreateDirectory(SAVE_FOLDER);
            }
        
            string fullPath = SAVE_FOLDER + filename;
            SaveData saveData = new SaveData();

            if (File.Exists(fullPath))
            {
                string json = File.ReadAllText(fullPath);
                saveData = JsonUtility.FromJson<SaveData>(json);
                Data = saveData;
            }
            else
            {
                Data = new SaveData();
            }
            
            return Data;
        }
    
        [System.Serializable]
        public class SaveData
        {
            public float highScore;
            public float comboScore;
        }
    
    }
}