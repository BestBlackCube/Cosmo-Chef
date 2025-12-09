using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Data;

public class END_Script : MonoBehaviour
{
    float timer = 0f;
    float Esc_timer = 0f;
    [SerializeField] Image Esc_bar;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (timer < 10f) timer += Time.deltaTime;
        else SceneManager.LoadScene("StartMenuScene");
        if (Input.GetKey(KeyCode.Escape))
        {
            Esc_timer += Time.deltaTime;
            Esc_bar.fillAmount = Esc_timer / 3f;
            if(Esc_timer > 3f)
            {
                SceneManager.LoadScene("StartMenuScene");
            }
        }
        else
        {
            if(Esc_timer > 0f)
            {
                Esc_timer = 0f;
                Esc_bar.fillAmount = 0f;
            }
        }
    }
}
