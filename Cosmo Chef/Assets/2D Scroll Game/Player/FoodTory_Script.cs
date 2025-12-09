using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class FoodTory_Script : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI food1;
    [SerializeField] TextMeshProUGUI food2;
    public int food1_Count = 1;
    public int food2_Count = 1;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        food1.text = "" + food1_Count;
        food2.text = "" + food2_Count;
    }
}
