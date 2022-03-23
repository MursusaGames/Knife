using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wheel : MonoBehaviour
{
           
    void FixedUpdate()
    {
        this.transform.Rotate(Vector3.forward, 1f);
    }
}
