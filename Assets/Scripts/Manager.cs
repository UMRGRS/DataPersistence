using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class Manager : MonoBehaviour
{
    public static Manager instance;

    public string playersNameA;
    public string playersNameB;
    public int points;
    public string bestScoreText;
    private void Awake()
    {
        if (instance != null) 
        {
            Destroy(gameObject);
            Manager.instance.Load();
            return;
        }
        instance = this;
        DontDestroyOnLoad(gameObject);
        Load();
    }
    [System.Serializable]
    class SaveData 
    {
        public string playersName;
        public int score;
    }
    public void Save() 
    {
        SaveData data = new SaveData();
        data.playersName = playersNameA;
        data.score = points;
        
        string json = JsonUtility.ToJson(data);

        File.WriteAllText(Application.persistentDataPath + "/savefile.json", json);
    }
    public void Load() 
    {
        string path = Application.persistentDataPath + "/savefile.json";
        if (File.Exists(path)) 
        {
            string json = File.ReadAllText(path);
            SaveData data = JsonUtility.FromJson<SaveData>(json);

            playersNameA = data.playersName;
            points = data.score;
            bestScoreText = "Best Score: " + playersNameA + " " + points;
        }
    }

}
