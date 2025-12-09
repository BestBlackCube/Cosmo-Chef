using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class InGameButton_Script : MonoBehaviour
{
    public void RetryButton()
    {
        SceneManager.LoadScene("InGameScene");
    }
    public void mainMenuButton()
    {
        SceneManager.LoadScene("StartMenuScene");
    }
}
