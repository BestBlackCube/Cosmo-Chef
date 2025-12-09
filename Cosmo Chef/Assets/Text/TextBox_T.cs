using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TextBox_T : MonoBehaviour
{
    public Text_Script TPM;
    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.layer == LayerMask.NameToLayer("Player"))
        {
            TPM.GetComponent<Text_Script>().WorldText_Count++;
            TPM.Text_input = true;
        }
    }
}
