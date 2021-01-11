using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetRandomizer : MonoBehaviour
{

    public Vector3 Dimensions = Vector3.one;
    public Vector3 Offset = Vector3.zero;
    public Transform TargetTransform;

    private GameObject _target;

    public GameObject RandomizeTarget()
    {

        // Calculate position
        Vector3 pos = Vector3.zero;
        pos.x = transform.position.x + Random.Range(-Dimensions.x / 2, Dimensions.x / 2) + Offset.x;
        pos.y = transform.position.y + Random.Range(-Dimensions.y / 2, Dimensions.y / 2) + Offset.y;
        pos.z = transform.position.z + Random.Range(-Dimensions.z / 2, Dimensions.z / 2) + Offset.z;
        TargetTransform.position = pos;

        TargetTransform.parent = this.transform;
        TargetTransform.localScale = Vector3.one * 0.05f;

        // prevent target of spawning inside the robot


        return TargetTransform.gameObject;

    }

    void OnDrawGizmosSelected()
    {

        Gizmos.color = Color.blue;
        Gizmos.DrawLine(
            transform.position + new Vector3(-Dimensions.x / 2, -Dimensions.y / 2, -Dimensions.z / 2) + Offset,
            transform.position + new Vector3(-Dimensions.x / 2, -Dimensions.y / 2, Dimensions.z / 2) + Offset);

        Gizmos.DrawLine(
            transform.position + new Vector3(Dimensions.x / 2, -Dimensions.y / 2, -Dimensions.z / 2) + Offset,
            transform.position + new Vector3(Dimensions.x / 2, -Dimensions.y / 2, Dimensions.z / 2) + Offset);

        Gizmos.DrawLine(
            transform.position + new Vector3(-Dimensions.x / 2, Dimensions.y / 2, -Dimensions.z / 2) + Offset,
            transform.position + new Vector3(-Dimensions.x / 2, Dimensions.y / 2, Dimensions.z / 2) + Offset);

        Gizmos.DrawLine(
            transform.position + new Vector3(Dimensions.x / 2, Dimensions.y / 2, -Dimensions.z / 2) + Offset,
            transform.position + new Vector3(Dimensions.x / 2, Dimensions.y / 2, Dimensions.z / 2) + Offset);

        Gizmos.DrawLine(
            transform.position + new Vector3(-Dimensions.x / 2, -Dimensions.y / 2, -Dimensions.z / 2) + Offset,
            transform.position + new Vector3(-Dimensions.x / 2, Dimensions.y / 2, -Dimensions.z / 2) + Offset);

        Gizmos.DrawLine(
            transform.position + new Vector3(Dimensions.x / 2, -Dimensions.y / 2, -Dimensions.z / 2) + Offset,
            transform.position + new Vector3(Dimensions.x / 2, Dimensions.y / 2, -Dimensions.z / 2) + Offset);

        Gizmos.DrawLine(
            transform.position + new Vector3(-Dimensions.x / 2, -Dimensions.y / 2, Dimensions.z / 2) + Offset,
            transform.position + new Vector3(-Dimensions.x / 2, Dimensions.y / 2, Dimensions.z / 2) + Offset);

        Gizmos.DrawLine(
            transform.position + new Vector3(Dimensions.x / 2, -Dimensions.y / 2, Dimensions.z / 2) + Offset,
            transform.position + new Vector3(Dimensions.x / 2, Dimensions.y / 2, Dimensions.z / 2) + Offset);

        Gizmos.DrawLine(
            transform.position + new Vector3(Dimensions.x / 2, Dimensions.y / 2, -Dimensions.z / 2) + Offset,
            transform.position + new Vector3(-Dimensions.x / 2, Dimensions.y / 2, -Dimensions.z / 2) + Offset);

        Gizmos.DrawLine(
            transform.position + new Vector3(Dimensions.x / 2, Dimensions.y / 2, Dimensions.z / 2) + Offset,
            transform.position + new Vector3(-Dimensions.x / 2, Dimensions.y / 2, Dimensions.z / 2) + Offset);

        Gizmos.DrawLine(
            transform.position + new Vector3(Dimensions.x / 2, -Dimensions.y / 2, -Dimensions.z / 2) + Offset,
            transform.position + new Vector3(-Dimensions.x / 2, -Dimensions.y / 2, -Dimensions.z / 2) + Offset);

        Gizmos.DrawLine(
            transform.position + new Vector3(Dimensions.x / 2, -Dimensions.y / 2, Dimensions.z / 2) + Offset,
            transform.position + new Vector3(-Dimensions.x / 2, -Dimensions.y / 2, Dimensions.z / 2) + Offset);


    }
}
