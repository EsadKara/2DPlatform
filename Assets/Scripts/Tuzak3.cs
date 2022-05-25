using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tuzak3 : MonoBehaviour
{
    public float hiz;
    void Start()
    {
        hiz = 180;
    }

   
    void Update()
    {
        transform.Rotate(Vector3.back * Time.deltaTime * hiz) ;
    }
}
