using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class FoodTory_Script : MonoBehaviour
{
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
            stage_Panel.GetComponent<Stage_Script>().Timer_Text.text = "CLEAR TIME: " + Mathf.Round(Clear_timer * 1000) / 1000;
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
