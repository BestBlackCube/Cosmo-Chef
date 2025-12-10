using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FoodTory_Script : MonoBehaviour
{
    [SerializeField] RankData_Script Data;
    [SerializeField] Player_Script player;
    public GameObject stage_Panel;
    public FoodDrop_Script drop;

    [SerializeField] TextMeshProUGUI food1;
    [SerializeField] TextMeshProUGUI food2;
    [SerializeField] TextMeshProUGUI food3;
    [SerializeField] GameObject Door;
    public int food1_Count = 0;
    public int food2_Count = 0;
    public int food3_Count = 0;
    public int food1_Max = 0;
    public int food2_Max = 0;
    public int food3_Max = 0;

    public int EndingCount = 0;
    public float Clear_timer = 0;
    public bool ChangeCount = true;
    public bool cleartimer = false;

    private RankData_JsonList RankDataList;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        MaxChange();
        food1.text = "" + food1_Count + "/" + food1_Max;
        food2.text = "" + food2_Count + "/" + food2_Max;
        food3.text = "" + food3_Count + "/" + food3_Max;

        if (cleartimer) Clear_timer += Time.deltaTime;

        if(food1_Count == food1_Max && food2_Count == food2_Max && food3_Count == food3_Max)
        {
            drop.dropFood = false;
            cleartimer = false;
            food1_Count = 0;
            food2_Count = 0;
            food3_Count = 0;
            EndingCount++;
            stage_Panel.SetActive(true);
            Door.SetActive(true);
            stage_Panel.GetComponent<Stage_Script>().Stage_Text.text = "STAGE " + EndingCount + " CLEAR!";
            stage_Panel.GetComponent<Stage_Script>().Timer_Text.text = "CLEAR TIME: " + Mathf.Floor(Clear_timer * 1000) / 1000;
            if (EndingCount == 1)
            {
                if (Clear_timer > 0) PlayerPrefs.SetFloat("Stage1_timer", Mathf.Floor(Clear_timer * 1000) / 1000);
                else PlayerPrefs.SetFloat("Stage1_timer", 9999);
            }
            else if (EndingCount == 2)
            {
                if (Clear_timer > 0) PlayerPrefs.SetFloat("Stage2_timer", Mathf.Floor(Clear_timer * 1000) / 1000);
                else PlayerPrefs.SetFloat("Stage2_timer", 9999);
            }
            else if (EndingCount == 3)
            {
                if (Clear_timer > 0) PlayerPrefs.SetFloat("Stage3_timer", Mathf.Floor(Clear_timer * 1000) / 1000);
                else PlayerPrefs.SetFloat("Stage3_timer", 9999);
            }
            else if (EndingCount == 4)
            {
                if (Clear_timer > 0) PlayerPrefs.SetFloat("Stage4_timer", Mathf.Floor(Clear_timer * 1000) / 1000);
                else PlayerPrefs.SetFloat("Stage4_timer", 9999);
            }
            else if (EndingCount == 5)
            {
                if (Clear_timer > 0) PlayerPrefs.SetFloat("Stage5_timer", Mathf.Floor(Clear_timer * 1000) / 1000);
                else PlayerPrefs.SetFloat("Stage5_timer", 9999);
            }
            else if (EndingCount == 6)
            {
                if (Clear_timer > 0) PlayerPrefs.SetFloat("Stage6_timer", Mathf.Floor(Clear_timer * 1000) / 1000);
                else PlayerPrefs.SetFloat("Stage6_timer", 9999);

                if (PlayerPrefs.GetFloat("Stage1_timer") > 0 && PlayerPrefs.GetFloat("Stage2_timer") > 0 &&
                   PlayerPrefs.GetFloat("Stage3_timer") > 0 && PlayerPrefs.GetFloat("Stage4_timer") > 0 &&
                   PlayerPrefs.GetFloat("Stage5_timer") > 0 && PlayerPrefs.GetFloat("Stage6_timer") > 0)
                {
                    RankDataList = Data.LoadData();
                    for(int i = 0; i < 10; i++)
                    {
                        if (RankDataList.rankDataList[i].Stage01_timer > PlayerPrefs.GetFloat("Stage1_timer") &&
                            RankDataList.rankDataList[i].Stage02_timer > PlayerPrefs.GetFloat("Stage2_timer") &&
                            RankDataList.rankDataList[i].Stage03_timer > PlayerPrefs.GetFloat("Stage3_timer") &&
                            RankDataList.rankDataList[i].Stage04_timer > PlayerPrefs.GetFloat("Stage4_timer") &&
                            RankDataList.rankDataList[i].Stage05_timer > PlayerPrefs.GetFloat("Stage5_timer") &&
                            RankDataList.rankDataList[i].Stage06_timer > PlayerPrefs.GetFloat("Stage6_timer"))
                        {
                            for (int j = 9; j > i; j--)
                            {
                                RankDataList.rankDataList[j + 1] = RankDataList.rankDataList[j];

                                //RankDataList.rankDataList[j + 1].Stage01_timer = RankDataList.rankDataList[j].Stage01_timer;
                                //RankDataList.rankDataList[j + 1].Stage02_timer = RankDataList.rankDataList[j].Stage02_timer;
                                //RankDataList.rankDataList[j + 1].Stage03_timer = RankDataList.rankDataList[j].Stage03_timer;
                                //RankDataList.rankDataList[j + 1].Stage04_timer = RankDataList.rankDataList[j].Stage04_timer;
                                //RankDataList.rankDataList[j + 1].Stage05_timer = RankDataList.rankDataList[j].Stage05_timer;
                                //RankDataList.rankDataList[j + 1].Stage06_timer = RankDataList.rankDataList[j].Stage06_timer;

                            }
                            if (RankDataList.rankDataList[10].Stage01_timer > 0)
                            {
                                RankDataList.rankDataList[10].Stage01_timer = 0;
                                RankDataList.rankDataList[10].Stage02_timer = 0;
                                RankDataList.rankDataList[10].Stage03_timer = 0;
                                RankDataList.rankDataList[10].Stage04_timer = 0;
                                RankDataList.rankDataList[10].Stage05_timer = 0;
                                RankDataList.rankDataList[10].Stage06_timer = 0;

                            }
                            RankDataList.rankDataList[i] = new RankData_Json
                            {
                                Stage01_timer = PlayerPrefs.GetFloat("Stage1_timer"),
                                Stage02_timer = PlayerPrefs.GetFloat("Stage2_timer"),
                                Stage03_timer = PlayerPrefs.GetFloat("Stage3_timer"),
                                Stage04_timer = PlayerPrefs.GetFloat("Stage4_timer"),
                                Stage05_timer = PlayerPrefs.GetFloat("Stage5_timer"),
                                Stage06_timer = PlayerPrefs.GetFloat("Stage6_timer")
                            };

                            Data.SaveData(RankDataList);
                            break;
                        }
                    }
                }
            }
        }
        Food_Maxup();

        if (Input.GetKey(KeyCode.Tab) && player.Dead_MoveLock == false && Clear_timer > 3f)
        {
            if (Input.GetKeyDown(KeyCode.C))
            {
                food1_Count = food1_Max;
                food2_Count = food2_Max;
                food3_Count = food3_Max;
            }
            if (Input.GetKeyDown(KeyCode.E))
            {
                food1_Count = food1_Max;
                food2_Count = food2_Max;
                food3_Count = food3_Max;
                EndingCount = 5;
            }
            if(Input.GetKeyDown(KeyCode.D))
            {
                Debug.Log("Stage 1_Timer : " + PlayerPrefs.GetFloat("Stage1_timer"));
                Debug.Log("Stage 2_Timer : " + PlayerPrefs.GetFloat("Stage2_timer"));
                Debug.Log("Stage 3_Timer : " + PlayerPrefs.GetFloat("Stage3_timer"));
                Debug.Log("Stage 4_Timer : " + PlayerPrefs.GetFloat("Stage4_timer"));
                Debug.Log("Stage 5_Timer : " + PlayerPrefs.GetFloat("Stage5_timer"));
                Debug.Log("Stage 6_Timer : " + PlayerPrefs.GetFloat("Stage6_timer"));
            }
        }
    }
    void Food_Maxup()
    {
        if(food1_Count > food1_Max)
        {
            player.PlayerHit = true;
            food1_Count--;
        }
        if (food2_Count > food2_Max)
        {
            player.PlayerHit = true;
            food2_Count--;
        }
        if (food3_Count > food3_Max)
        {
            player.PlayerHit = true;
            food3_Count--;
        }
    }

    void MaxChange()
    {
        if(ChangeCount == true)
        {
            food1_Max = Random.Range(1, 6);
            food2_Max = Random.Range(1, 6);
            food3_Max = Random.Range(1, 6);
            ChangeCount = false;
        }
    }
}
