using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Retry_Script : MonoBehaviour
{
    bool Retry = false;
    private void OnMouseOver()
    {
        Retry = true;
    }
    private void OnMouseExit()
    {
        Retry = false;   
    }
    private void OnMouseDown()
    {
        if(Retry == true)
        {
            SceneManager.LoadScene("ScrollScene");
        }
    }
}
