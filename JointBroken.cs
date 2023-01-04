using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JointBroken : MonoBehaviour
{
    private Rigidbody jointRigidbody;
    private void Start() {
        jointRigidbody = GetComponent<Rigidbody>();
    }
    void OnJointBreak(float breakForce)
    {
        print("a Joint broke");
        jointRigidbody.useGravity = true;
    }
}
