using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class BlackScreen_Script : MonoBehaviour
{
    [SerializeField] Image Black;
    [SerializeField] GameObject CountDown;
    [SerializeField] GameObject KeyGuide;
    [SerializeField] FoodTory_Script foodtory;
    [SerializeField] Player_Script player;

    float Screen_timer = 0f;
    float timerCount = 3f;
    float Textenabled_timer = 0f;
    bool timer_lock = true;
    bool Down = false;
    bool Textenabled = false;

    public bool nextStage = false;
    float BlackOn = 0f;
    float BlackOff = 0f;
    float Onedelay_timer = 0f;
    float delay_timer = 0f;
    // Start is called before the first frame update
    void Awake()
    {
        Color color = Black.color;
        color.a = 1f;
        Black.color = color;
    }

    // Update is called once per frame
    void Update()
    {
        if(timer_lock == true)
        {
            if (Onedelay_timer < 3f) Onedelay_timer += Time.deltaTime;
            else
            {
                if (Screen_timer < 2f)
                {
                    Screen_timer += Time.deltaTime;
                    Color color = Black.color;
                    color.a = Mathf.Lerp(1.0f, 0.0f, Screen_timer);
                    Black.color = color;
                }
                else
                {
                    Down = true;
                    timer_lock = false;
                }
            }
            
        }

        if(nextStage == true)
        {
            if (BlackOn < 2f)
            {
                BlackOn += Time.deltaTime;
                Color color = Black.color;
                color.a = Mathf.Lerp(0.0f, 1.0f, BlackOn);
                Black.color = color;
            }
            else
            {
                if (foodtory.EndingCount >= 5) SceneManager.LoadScene("EndingScene");
                if (delay_timer < 3f)
                {
                    delay_timer += Time.deltaTime;
                    player.Dead_MoveLock = true;
                    player.transform.position = new Vector3(0, -3, 0);
                }
                else
                {
                    if (BlackOff < 2f)
                    {
                        BlackOff += Time.deltaTime;
                        Color color = Black.color;
                        color.a = Mathf.Lerp(1.0f, 0.0f, BlackOff);
                        Black.color = color;
                    }
                    else
                    {
                        Down = true;
                        nextStage = false;
                    }
                }
            }
        }
        else
        {
            BlackOn = 0f;
            BlackOff = 0f;
            delay_timer = 0f;
        }

        if (Down == true)
        {
            CountDown.SetActive(true);
            KeyGuide.SetActive(true);

            Color color = CountDown.GetComponent<TextMeshProUGUI>().color;
            if (color.a == 0f)
            {
                color.a = 1f;
                CountDown.GetComponent<TextMeshProUGUI>().color = color;
            }
            if (timerCount > 0f)
            {
                timerCount -= Time.deltaTime;
                if (timerCount > 2f) CountDown.GetComponent<TextMeshProUGUI>().text = "3";
                if (2f > timerCount && timerCount > 1f) CountDown.GetComponent<TextMeshProUGUI>().text = "2";
                if (1f > timerCount && timerCount > 0f) CountDown.GetComponent<TextMeshProUGUI>().text = "1";
                if (0f > timerCount)
                {
                    CountDown.GetComponent<TextMeshProUGUI>().text = "START!";
                    foodtory.drop.dropFood = true;
                    foodtory.ChangeCount = true;
                    player.Dead_MoveLock = false;
                    Textenabled = true;
                    Down = false;
                }
            }
            if(foodtory.EndingCount == 0)
            {
                Color color2 = KeyGuide.GetComponent<SpriteRenderer>().color;
                if (color2.a == 0f)
                {
                    color2.a = 1f;
                    KeyGuide.GetComponent<SpriteRenderer>().color = color2;
                }
            }
        }
        else
        {
            timerCount = 3f;
        }

        if(Textenabled == true)
        {
            if(Textenabled_timer < 2f)
            {
                Textenabled_timer += Time.deltaTime;
                Color color = CountDown.GetComponent<TextMeshProUGUI>().color;
                color.a = Mathf.Lerp(1.0f, 0.0f, Textenabled_timer);
                CountDown.GetComponent<TextMeshProUGUI>().color = color;
                if (foodtory.EndingCount == 0)
                {
                    Color color2 = KeyGuide.GetComponent<SpriteRenderer>().color;
                    color2.a = Mathf.Lerp(1.0f, 0.0f, Textenabled_timer);
                    KeyGuide.GetComponent<SpriteRenderer>().color = color2;
                }
            }
            else
            {
                Textenabled_timer = 0f;
                Textenabled = false;
            }
        }
    }
}
