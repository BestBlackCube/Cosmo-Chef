using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class RankData_Json
{
    public float Stage01_timer;
    public float Stage02_timer;
    public float Stage03_timer;
    public float Stage04_timer;
    public float Stage05_timer;
    public float Stage06_timer;
}
[System.Serializable]
public class RankData_JsonList
{
    public RankData_Json[] rankDataList;
}
