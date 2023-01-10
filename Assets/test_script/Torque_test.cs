using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Torque_test : MonoBehaviour
{
    Rigidbody rb;
    Vector3 torque;

    public GameObject joint;

    void Start()
    {
        //joint = GameObject.Find("joint_1");
        //rb = GetComponent<Rigidbody>();
        rb = joint.GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        torque = Vector3.zero;
        if (Input.GetKey("right"))
        {
            torque = new Vector3(5.0f, 0.0f, 0.0f);
        }

        if (Input.GetKey("left"))
        {
            torque = new Vector3(-5.0f, 0.0f, 0.0f);
        }

        if (Input.GetKey("up"))
        {
            torque = new Vector3(0.0f, 0.0f, -5.0f);
        }

        if (Input.GetKey("down"))
        {
            torque = new Vector3(0.0f, 0.0f, -5.0f);
        }

        // 現在の角速度
        print(rb.angularVelocity);

        // トルクを加える
        rb.AddTorque(torque, ForceMode.Acceleration);
    }
}
