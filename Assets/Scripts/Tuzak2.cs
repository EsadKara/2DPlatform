using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tuzak2 : MonoBehaviour
{
    Rigidbody2D fizik;
    public float hiz;
    void Start()
    {
        fizik = gameObject.GetComponent<Rigidbody2D>();
        fizik.AddForce(Vector3.left * hiz);
    }

   
    void Update()
    {
      
    }
}
