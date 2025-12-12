using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Ending_Audio : MonoBehaviour
{
    [SerializeField] AudioSource MainAudio;

    // Start is called before the first frame update
    void Start()
    {
        float MainSound = PlayerPrefs.GetFloat("mainAudio");
        MainSoundChange(MainSound);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void MainSoundChange(float value)
    {
        PlayerPrefs.SetFloat("mainAudio", value);
        float Sound = PlayerPrefs.GetFloat("mainAudio");
        MainAudio.volume = Sound;
    }
}
