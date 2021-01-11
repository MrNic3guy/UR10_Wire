using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class URController : MonoBehaviour
{
    public Transform Joint_01;
    public Transform Joint_02;
    public Transform Joint_03;
    public Transform Joint_04;
    public Transform Joint_05;
    public Transform Joint_06;

    [Range(-180.0f, 180.0f)]
    public float Joint1Rotation;

    [Range(-180.0f, 180.0f)]
    public float Joint2Rotation;

    [Range(-180.0f, 180.0f)]
    public float Joint3Rotation;

    [Range(-180.0f, 180.0f)]
    public float Joint4Rotation;

    [Range(-180.0f, 180.0f)]
    public float Joint5Rotation;

    [Range(-180.0f, 180.0f)]
    public float Joint6Rotation;


    public List<Collider> Collider;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //Joint_01.localRotation = Quaternion.Euler(0, Joint1Rotation, 0);
        //Joint_02.localRotation = Quaternion.Euler(0, Joint2Rotation, 0);
        //Joint_03.localRotation = Quaternion.Euler(0, Joint3Rotation, 0);
        //Joint_04.localRotation = Quaternion.Euler(0, Joint4Rotation, 0);
        //Joint_05.localRotation = Quaternion.Euler(0, Joint5Rotation, 0);
        //Joint_06.localRotation = Quaternion.Euler(0, Joint6Rotation, 0);

        
    }
}
