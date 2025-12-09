using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class End_Script : MonoBehaviour
{
    bool end = false;
    private void OnMouseOver()
    {
        end = true;
    }
    private void OnMouseExit()
    {
        end = false;
    }
    private void OnMouseDown()
    {
        if (end == true)
        {
            Application.Quit();
        }
    }
}
