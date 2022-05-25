using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bgSes : MonoBehaviour
{
    public static GameObject instance;
    void Start()
    {
        if (instance == null)
        {
            instance = gameObject;
            DontDestroyOnLoad(instance);
        }
        else
        {
            Destroy(gameObject);
        }
    }

}
