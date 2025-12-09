using System.Collections;
using System.Collections.Generic;
using System.Threading;
using TMPro;
using UnityEngine;

public class Text_Script : MonoBehaviour
{
    public int WorldText_Count = 0;
    public bool Text_input = false;
    bool Transform_Change = false;
    bool Timer_Text = false;
    float text_timer = 0f;

    public TextMeshProUGUI tmpro;
    public GameObject textBox;
    Color TMPcolor;

    // Start is called before the first frame update
    void Start()
    {
        tmpro = GetComponent<TextMeshProUGUI>();
        TMPcolor = tmpro.color;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        switch(WorldText_Count)
        {
            case 0:
                break;
            case 1:
                tmpro.text = "스토리의 1번째 이야기 진행중...";
                Text_timerChange(0f);
                if (Transform_Change)
                {
                    textBox.transform.position = new Vector3(45, 0, 0);
                    Transform_Change = false;
                }
                break;
            case 2:
                tmpro.text = "스토리의 2번째 이야기 진행중...";
                Text_timerChange(0f);
                if (Transform_Change)
                {
                    textBox.transform.position = new Vector3(80, 0, 0);
                    Transform_Change = false;
                }
                break;
            case 3:
                tmpro.text = "스토리의 3번째 이야기 진행중...";
                Text_timerChange(0f);
                if (Transform_Change)
                {
                    textBox.transform.position = new Vector3(120, 0, 0);
                    Transform_Change = false;
                }
                break;
            case 4:
                tmpro.text = "스토리의 4번째 이야기 진행중...";
                Text_timerChange(0f);
                if (Transform_Change)
                {
                    textBox.transform.position = new Vector3(160, 0, 0);
                    Transform_Change = false;
                }
                break;
            case 5:
                tmpro.text = "건물이 보인다.. 들어가자..";
                Timer_Text = true;
                Text_timerChange(5f);
                break;
            default:
                break;
        }
    }
    void Text_timerChange(float limit)
    {
        if(!Timer_Text)
        {
            if (Text_input)
            {
                TMPcolor.a = Mathf.Lerp(TMPcolor.a, 1f, Time.deltaTime);
                tmpro.color = TMPcolor;
            }
            else
            {
                TMPcolor.a = Mathf.Lerp(TMPcolor.a, 0f, Time.deltaTime);
                if (tmpro.color.a < 0.01f)
                {
                    TMPcolor.a = 0f;
                    Transform_Change = true;
                }
                tmpro.color = TMPcolor;
            }
        }
        else
        {
            if (text_timer < limit)
            {
                text_timer += Time.deltaTime;
                TMPcolor.a = Mathf.Lerp(TMPcolor.a, 1f, Time.deltaTime);
                tmpro.color = TMPcolor;
            }
            else
            {
                TMPcolor.a = Mathf.Lerp(TMPcolor.a, 0f, Time.deltaTime);
                if (tmpro.color.a < 0.01f)
                {
                    TMPcolor.a = 0f;
                }
                tmpro.color = TMPcolor;
            }
        }
    }
}
