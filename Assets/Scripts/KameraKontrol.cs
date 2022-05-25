using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KameraKontrol : MonoBehaviour
{
    public Transform karakter;

    private void FixedUpdate()
    {
        //transform.position = Vector3.Lerp(transform.position, karakter.position, damping) + offset;
        transform.position = new Vector3(karakter.position.x + 5f, transform.position.y, -10);
        if (transform.position.x > 56)
        {
            transform.position = new Vector3(56, transform.position.y, -10);
        }
    }
}
