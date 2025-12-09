using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class mainMenu_Script : MonoBehaviour
{
    bool main = false;
    private void OnMouseOver()
    {
        main = true;
    }
    private void OnMouseExit()
    {
        main = false;
    }
    private void OnMouseDown()
    {
        if (main == true)
        {
            SceneManager.LoadScene("StartMenuScene");
        }
    }
}
