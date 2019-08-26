using System;
using System.Net.Sockets;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Transform playerTransform;
    private Rigidbody rigidbody;
    
    public float maxForwardSpeed;
    public float maxSideSpeed;

    private void Start()
    {
        playerTransform = GetComponent<Transform>();
        rigidbody = GetComponent<Rigidbody>();
    }

    public void Move(float forwardInput, float sideInput)
    {
        float forward = maxForwardSpeed * forwardInput * Time.fixedDeltaTime;
        float side = maxSideSpeed * sideInput * Time.fixedDeltaTime;
        playerTransform.Translate(side, 0.0f, forward, Space.Self);
    }

    public void Rotate(float angle)
    {
        playerTransform.Rotate(Vector3.up, angle);
    }

    public void SetRotation(float angle)
    {
        playerTransform.localEulerAngles = new Vector3(0.0f, angle, 0.0f);
    }
}