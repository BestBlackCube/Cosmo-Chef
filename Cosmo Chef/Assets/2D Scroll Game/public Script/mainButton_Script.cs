using System.Collections;
using System.Collections.Generic;
using System.Data;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;
using System.Linq;

public class mainButton_Script : MonoBehaviour
{
    [SerializeField] GameObject SettingObject;
    [SerializeField] GameObject RankObject;
    [SerializeField] GameObject[] RankInDataObject;

    [SerializeField] AudioSource MainAudio;

    [SerializeField] Image MainSlider;
    [SerializeField] Slider mainslider;
    [SerializeField] GameObject mainText;

    [SerializeField] Image InGameSlider;
    [SerializeField] Slider InGameslider;
    [SerializeField] GameObject InGameText;

    [SerializeField] RankData_Script Data;
    private RankData_JsonList RankDataList;

    public void StartButton()
    {
        SceneManager.LoadScene("InGameScene");
    }
    public void RankButton()
    {
        RankDataList = Data.LoadData();
        if (RankDataList != null || RankDataList.rankDataList.Length == 11)
        {
            for (int i = 0; i < 10; i++)
            {
                if (RankDataList.rankDataList[i].Stage01_timer != 9999)
                    RankInDataObject[i].GetComponent<RankText_Script>().RankTextBox[0].text =
                        "Stage 1\n" + RankDataList.rankDataList[i].Stage01_timer.ToString();
                else RankInDataObject[i].GetComponent<RankText_Script>().RankTextBox[0].text = "NoData";

                if (RankDataList.rankDataList[i].Stage02_timer != 9999)
                    RankInDataObject[i].GetComponent<RankText_Script>().RankTextBox[1].text =
                        "Stage 2\n" + RankDataList.rankDataList[i].Stage02_timer.ToString();
                else RankInDataObject[i].GetComponent<RankText_Script>().RankTextBox[1].text = "NoData";

                if (RankDataList.rankDataList[i].Stage03_timer != 9999)
                    RankInDataObject[i].GetComponent<RankText_Script>().RankTextBox[2].text =
                        "Stage 3\n" + RankDataList.rankDataList[i].Stage03_timer.ToString();
                else RankInDataObject[i].GetComponent<RankText_Script>().RankTextBox[2].text = "NoData";

                if (RankDataList.rankDataList[i].Stage04_timer != 9999)
                    RankInDataObject[i].GetComponent<RankText_Script>().RankTextBox[3].text =
                        "Stage 4\n" + RankDataList.rankDataList[i].Stage04_timer.ToString();
                else RankInDataObject[i].GetComponent<RankText_Script>().RankTextBox[3].text = "NoData";

                if (RankDataList.rankDataList[i].Stage05_timer != 9999)
                    RankInDataObject[i].GetComponent<RankText_Script>().RankTextBox[4].text =
                        "Stage 5\n" + RankDataList.rankDataList[i].Stage05_timer.ToString();
                else RankInDataObject[i].GetComponent<RankText_Script>().RankTextBox[4].text = "NoData";

                if (RankDataList.rankDataList[i].Stage06_timer != 9999)
                    RankInDataObject[i].GetComponent<RankText_Script>().RankTextBox[5].text =
                        "Stage 6\n" + RankDataList.rankDataList[i].Stage06_timer.ToString();
                else RankInDataObject[i].GetComponent<RankText_Script>().RankTextBox[5].text = "NoData";
            }
            RankObject.SetActive(true);
        }
    }
    public void SettingButton()
    {
        SettingObject.SetActive(true);
    }
    public void ExitButton()
    {
        Application.Quit();
    }

    public void Setting_Close()
    {
        SettingObject.SetActive(false);
    }
    public void Rank_Close()
    {
        RankObject.SetActive(false);
    }
    private void Start()
    {
        float MainSound = PlayerPrefs.GetFloat("mainAudio");
        mainslider.value = MainSound;
        MainSoundChange(MainSound);

        float InGameSound = PlayerPrefs.GetFloat("InGameAudio");
        InGameslider.value = InGameSound;
        InGameSoundChange(InGameSound);

        mainslider.onValueChanged.AddListener(MainSoundChange);
        InGameslider.onValueChanged.AddListener(InGameSoundChange);
    }
    public void MainSoundChange(float value)
    {
        MainSlider.fillAmount = value;
        PlayerPrefs.SetFloat("mainAudio", value);
        float Sound = PlayerPrefs.GetFloat("mainAudio");
        MainAudio.volume = Sound;
        float Con = 100 * value;
        mainText.GetComponent<TextMeshProUGUI>().text = "" + Con.ToString("F0");
    }
    public void InGameSoundChange(float value)
    {
        InGameSlider.fillAmount = value;
        PlayerPrefs.SetFloat("InGameAudio", value);
        float Sound = PlayerPrefs.GetFloat("InGameAudio");
        float Con = 100 * value;
        InGameText.GetComponent<TextMeshProUGUI>().text = "" + Con.ToString("F0");
    }
}
