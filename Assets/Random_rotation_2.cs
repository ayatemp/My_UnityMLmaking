using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Random_rotation_2 : MonoBehaviour
{
    float radius = 0.0f;
    float speed = 0.0f;
    float degree = 0.0f;

    void Update()
    {
        this.transform.rotation = Quaternion.Euler(0, degree, 0);
        degree += 0.1f;
    }
}
