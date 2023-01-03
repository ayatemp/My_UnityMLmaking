using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoalMove : MonoBehaviour
{
    float speed = 1.0f;
    float radius = 9.0f;

    void Update()
    {
        this.transform.localPosition = new Vector3(radius * Mathf.Sin(Time.time * speed), 9.0f, radius * Mathf.Cos(Time.time * speed));
    }
}
