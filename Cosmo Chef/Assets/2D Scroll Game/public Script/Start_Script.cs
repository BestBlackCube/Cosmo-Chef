using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Start_Script : MonoBehaviour
{
    bool Start = false;
    private void OnMouseOver()
    {
        Start = true;    
    }
    private void OnMouseExit()
    {
        Start = false;
    }
    private void OnMouseDown()
    {
        if(Start == true)
        {
            SceneManager.LoadScene("ScrollScene");
        }
    }
}
