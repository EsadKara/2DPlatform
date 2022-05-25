using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class yerdeMi : MonoBehaviour
{
    public bool yerdemi;
    public LayerMask layer;
    void Start()
    {
        
    }

   
    void Update()
    {
        RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector3.down, 0.1f,layer);
        if (hit.collider != null)  
        {
            yerdemi = true;
        }
        else
        {
            yerdemi = false;
        }
    }
}
