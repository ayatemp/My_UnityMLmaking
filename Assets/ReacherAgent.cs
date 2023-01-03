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
    public Transform Base;
    public Transform Arm1;
    public Transform Arm2;
    public Transform Wrist;

    public override void Initialize()
    {
        
    }

    public override void CollectObservations(VectorSensor sensor)
    {
        
    }

    public override void OnActionReceived(ActionBuffers actions)
    {
        
    }

}
