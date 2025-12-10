using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class RankData_Script : MonoBehaviour
{
    private string filePath;

    private RankData_Json RankData;

    // Start is called before the first frame update
    void Awake()
    {
        filePath = System.IO.Path.Combine(Application.persistentDataPath, "StageTimerData.json");

        if (!File.Exists(filePath))
        {
            string path = Path.Combine(Application.streamingAssetsPath, "StageTimerData.json");
            byte[] data = null;
            data = File.ReadAllBytes(path);
            File.WriteAllBytes(filePath, data);
        }
    }

    public void SaveData(RankData_JsonList dataList)
    {
        string jsonData = JsonUtility.ToJson(dataList);
        File.WriteAllText(filePath, jsonData);
    }
    public RankData_JsonList LoadData()
    {
        if (File.Exists(filePath))
        {
            string jsonData = File.ReadAllText(filePath);
            return JsonUtility.FromJson<RankData_JsonList>(jsonData);
        }
        else return null;
    }
}
