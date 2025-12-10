using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SoundSetting_Script : MonoBehaviour
{
    [SerializeField] GameObject SettingObject;

    [SerializeField] Image MainSlider;
    [SerializeField] Slider mainslider;
    [SerializeField] GameObject mainText;

    [SerializeField] AudioSource InGameBackAudio;
    [SerializeField] AudioSource InGameAudio;

    [SerializeField] Image InGameSlider;
    [SerializeField] Slider InGameslider;
    [SerializeField] GameObject InGameText;
    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            if (SettingObject.activeSelf == false)
            {
                SettingObject.SetActive(true);
                InGameBackAudio.Pause();
                Time.timeScale = 0;
            }
            else
            {
                SettingObject.SetActive(false);
                InGameBackAudio.Play();
                Time.timeScale = 1;
            }
        }
    }
    public void SettingClose_Button()
    {
        SettingObject.SetActive(false);
        InGameBackAudio.Play();
        Time.timeScale = 1;
    }
    public void MainMenu_Button()
    {
        InGameBackAudio.Play();
        Time.timeScale = 1;
        SceneManager.LoadScene("StartMenuScene");
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
        InGameBackAudio.volume = Sound;
        float Con = 100 * value;
        mainText.GetComponent<TextMeshProUGUI>().text = "" + Con.ToString("F0");
    }
    public void InGameSoundChange(float value)
    {
        InGameSlider.fillAmount = value;
        PlayerPrefs.SetFloat("InGameAudio", value);
        float Sound = PlayerPrefs.GetFloat("InGameAudio");
        InGameAudio.volume = Sound;
        float Con = 100 * value;
        InGameText.GetComponent<TextMeshProUGUI>().text = "" + Con.ToString("F0");
    }
}
