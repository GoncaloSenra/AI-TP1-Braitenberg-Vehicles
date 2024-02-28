using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TheMazeCameraController : MonoBehaviour
{

    public int Speed = 1;

    void Update()
    {
        
        float zVal = Input.GetAxis("Vertical") * Speed;

        transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z + zVal);
    }
}
