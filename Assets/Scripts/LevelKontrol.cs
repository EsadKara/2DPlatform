using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelKontrol : MonoBehaviour
{

    public Button[] butonlar;
    public Image[] kilitler;

    void Start()
    {
        
        for (int i = 0; i < butonlar.Length; i++)
        {
            if (i <= PlayerPrefs.GetInt("level"))
            {
                butonlar[i].interactable = true;
            }
            else
            {
                butonlar[i].interactable = false;
            }
        }
        for (int i = 0; i < kilitler.Length; i++)
        {
            if (i <= PlayerPrefs.GetInt("level"))
            {
                kilitler[i].enabled = false;
            }
            else
            {
                kilitler[i].enabled = true;
            }
        }
    }
 
    void Update()
    {
        
    }
}
