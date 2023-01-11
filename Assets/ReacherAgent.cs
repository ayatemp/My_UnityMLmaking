using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.MLAgents;
using Unity.MLAgents.Sensors;
using Unity.MLAgents.Actuators;
using Unity.MLAgentsExamples;

[RequireComponent(typeof(JointDriveController))]
public class ReacherAgent : Agent
{
    [Header("Hand Setting")]
    public GameObject Joint1;
    public GameObject Arm1;
    public GameObject Joint2;
    public GameObject Arm2;
    public GameObject Palm;
    public GameObject Goal;

    float goalSpeed = 1.0f;

    Rigidbody Joint1_rb;
    Rigidbody Joint2_rb;
    Rigidbody Palm_rb;

    Collider Goal_co;

    public Palmscript palmscript;

    public override void Initialize()
    {
        Joint1_rb = Joint1.GetComponent<Rigidbody>();
        Joint2_rb = Joint1.GetComponent<Rigidbody>();
        Palm_rb = Palm.GetComponent<Rigidbody>();
        Goal_co = Goal.GetComponent<Collider>();
    }

    //エピソード開始時におけるAgentの行動
    public override void OnEpisodeBegin()
    {
       
    }


    //観察にデータを渡す
    public override void CollectObservations(VectorSensor sensor)
    {
        //今回渡すデータ一覧
        /*
         0~2　関節Aの位置XYZ
         3~6　関節Aの回転XYZW
         7~9　関節Aの角加速度XYZ
         10~12　関節Aの加速度XYZ
         13~15　関節Aの位置XYZ
         16~19　関節Aの回転XYZW
         20~22　関節Aの角加速度XYZ
         23~25　関節Aの加速度XYZ
         26~28　ゴールの位置XYZ
         29~31　手の位置XYZ
         32　ゴールの速度
         */

        //関節A
        sensor.AddObservation(Joint1.transform.localPosition);
        sensor.AddObservation(Joint1.transform.rotation);
        sensor.AddObservation(Joint1_rb.angularVelocity);
        sensor.AddObservation(Joint1_rb.velocity);

        //関節B
        sensor.AddObservation(Joint2.transform.localPosition);
        sensor.AddObservation(Joint2.transform.rotation);
        sensor.AddObservation(Joint2_rb.angularVelocity);
        sensor.AddObservation(Joint2_rb.velocity);

        //ゴールの位置
        sensor.AddObservation(Goal.transform.localPosition);
        sensor.AddObservation(goalSpeed);
    }


    //行動実施時に呼ばれる
    public override void OnActionReceived(ActionBuffers actions)
    {
        //関節Aのトルク設定
        var TorqueX = Mathf.Clamp(actions.ContinuousActions[0], -1f, 1f) * 150f;
        var TorqueZ = Mathf.Clamp(actions.ContinuousActions[1], -1f, 1f) * 150f;
        Joint1_rb.AddTorque(new Vector3(TorqueX, 0f, TorqueZ));

        //関節Aのトルク設定
        TorqueX = Mathf.Clamp(actions.ContinuousActions[2], -1f, 1f) * 150f;
        TorqueZ = Mathf.Clamp(actions.ContinuousActions[3], -1f, 1f) * 150f;
        Joint2_rb.AddTorque(new Vector3(TorqueX, 0f, TorqueZ));

        //palmがgoalに衝突していたら報酬
        if(palmscript.collision == true)
        {
            print("AddReward_now");
            AddReward(0.01f);
        }
    }

}
