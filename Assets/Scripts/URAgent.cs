using System.Collections;
using System.Collections.Generic;
using Unity.MLAgents;
using Unity.MLAgents.Actuators;
using Unity.MLAgents.Sensors;
using UnityEngine;

public class URAgent : Agent
{

    public URController URController;
    public TargetRandomizer TargetRandomizer;
    public Transform EndEffectorTransform;

    private Transform _target;
    private float _distanceToTarget;

    public override void Initialize()
    {
        ResetParemeters();
    }

    public override void CollectObservations(VectorSensor sensor)
    {
        // Add rotation of each joint
        sensor.AddObservation(URController.Joint_01.localRotation);
        sensor.AddObservation(URController.Joint_02.localRotation);
        sensor.AddObservation(URController.Joint_03.localRotation);
        sensor.AddObservation(URController.Joint_04.localRotation);
        sensor.AddObservation(URController.Joint_05.localRotation);

        // Add Vector from end effector to target
        sensor.AddObservation(EndEffectorTransform.position - _target.position);

        //// add normalized end effector position (sphere)
        //sensor.AddObservation(URController.transform.InverseTransformPoint(EndEffectorTransform.position) / 4);

        //// add target sphere position
        //sensor.AddObservation(URController.transform.InverseTransformPoint(_target.position) / 4);

    }

    public override void OnActionReceived(ActionBuffers actionBuffers)
    {
        var actionJoint_01 = 2f * Mathf.Clamp(actionBuffers.ContinuousActions[0], -1f, 1f);
        var actionJoint_02 = 2f * Mathf.Clamp(actionBuffers.ContinuousActions[1], -1f, 1f);
        var actionJoint_03 = 2f * Mathf.Clamp(actionBuffers.ContinuousActions[2], -1f, 1f);
        var actionJoint_04 = 2f * Mathf.Clamp(actionBuffers.ContinuousActions[3], -1f, 1f);
        var actionJoint_05 = 2f * Mathf.Clamp(actionBuffers.ContinuousActions[4], -1f, 1f);

        URController.Joint_01.Rotate(0, actionJoint_01, 0, Space.Self);
        URController.Joint_02.Rotate(0, actionJoint_02, 0, Space.Self);
        URController.Joint_03.Rotate(0, actionJoint_03, 0, Space.Self);
        URController.Joint_04.Rotate(0, actionJoint_04, 0, Space.Self);
        URController.Joint_05.Rotate(0, actionJoint_05, 0, Space.Self);

        // Reward for time
        AddReward(-0.001f);

        var distToTarget = (_target.position - EndEffectorTransform.position).magnitude;

        var distReward = (_distanceToTarget - distToTarget) / 10;

        // Add Reward for getting closer to target
        AddReward(distReward);


        // Punish collisions


        // Reward for reaching goal

        if (distToTarget < 0.1f)
        {
            AddReward(1);
            EndEpisode();
        }

    }

    public override void OnEpisodeBegin()
    {

        //Reset the parameters when the Agent is reset.
        ResetParemeters();
    }

    private void ResetParemeters()
    {
        Debug.Log("Reset");
        _target = TargetRandomizer.RandomizeTarget().transform;
        _distanceToTarget = (_target.position - EndEffectorTransform.position).magnitude;
    }

    public override void Heuristic(in ActionBuffers actionsOut)
    {
        var continuousActionsOut = actionsOut.ContinuousActions;
        continuousActionsOut[0] = 10;// Input.GetAxis("Horizontal");
        continuousActionsOut[1] = Input.GetAxis("Vertical");
        continuousActionsOut[2] = Input.GetAxis("Horizontal");
        continuousActionsOut[3] = Input.GetAxis("Vertical");
        continuousActionsOut[4] = Input.GetAxis("Horizontal");

    }
}
