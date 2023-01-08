using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoalMove : MonoBehaviour
{
    public float speed = 1.0f;
    public float radius = -15.0f;

    void Update()
    {
        this.transform.localPosition = new Vector3(radius * Mathf.Sin(Time.time * speed), 20.0f, radius * Mathf.Cos(-Time.time * speed));
    }
}
