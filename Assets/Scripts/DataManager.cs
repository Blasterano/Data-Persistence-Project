using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class DataManager : MonoBehaviour
{
    public static DataManager instance;

    public string playerName;
    public string highScoreName = "";
    public int highScore = 0;

    private void Awake()
    {
        if(instance != null)
        {
            Destroy(this.gameObject);
            return;
        }

        instance = this;
        DontDestroyOnLoad(gameObject);

        LoadScore();

    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }

    [System.Serializable]
    class SaveData
    {
        public int score;
        public string playerName;
    }

    public void SaveScore()
    {
        SaveData data = new SaveData();
        data.score = highScore;
        data.playerName = highScoreName;

        string json=JsonUtility.ToJson(data);

        File.WriteAllText(Application.persistentDataPath + "/Savefile.json", json);

    }

    public void LoadScore()
    {
        string path = Application.persistentDataPath + "/Savefile.json";

        if(File.Exists(path))
        {
            string json = File.ReadAllText(path);

            SaveData data = JsonUtility.FromJson<SaveData>(json);

            highScoreName = data.playerName;
            highScore = data.score;
        }
    }

    public void Reset()
    {
        highScoreName = "";
        highScore = 0;
        SaveScore();
}
}
