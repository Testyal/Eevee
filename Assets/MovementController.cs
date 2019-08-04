using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(BoxCollider))]
[RequireComponent(typeof(Animator))]

public class MovementController : MonoBehaviour
{
    private Rigidbody rigidBody;
    /* private List<ContactPoint> contactPoints = new List<ContactPoint>(6); */

    private Transform cameraController;

    private Animator animator;

    private Vector3 velocity;

    public float forwardSpeed;
    public float strafeSpeed;

    public float jumpSpeed;
    private bool isJumping;

    // Start is called before the first frame update 
    void Start()
    {
        cameraController = GameObject.Find("Camera Controller").transform;

        rigidBody = GetComponent<Rigidbody>();
        animator = GetComponent<Animator>();
    }

    // FixedUpdate is called once before each frame's physics update
    void FixedUpdate()
    {
        /* Movement */
        Vector3 forwardVelocity = new Vector3();
        Vector3 rightVelocity = new Vector3();

        float v = Input.GetAxis("Vertical");
        float h = Input.GetAxis("Horizontal");

        if (v >= 0.1 || v <= -0.1)
        {
            /* TODO: Have character turn rapidly to camera forward position rather than this janky snap */
            forwardVelocity = cameraController.forward;
            forwardVelocity.y = 0;
            forwardVelocity.Normalize();

            transform.forward = forwardVelocity;
        }

        if (h >= 0.1 || h <= -0.1)
        {
            rightVelocity = cameraController.right;
            rightVelocity.y = 0;
            rightVelocity.Normalize();
        }

        /* TODO: Make backward speed slower than forward speed (so animation looks alright) */
        velocity = forwardVelocity * v * forwardSpeed + rightVelocity * h * strafeSpeed;

        transform.Translate(velocity * Time.deltaTime, Space.World);

        /* TODO: Have this float decreases smoothly (so hair doesn't snap awkwardly into place after running stops) */
        animator.SetFloat("Speed", v * forwardSpeed);

        /* Jumping */
        /* TODO: Fix collision with walls when jumping */
        /*
        float j = Input.GetAxis("Jump");
        if (j >= 0.1 && !isJumping)
        {
            isJumping = true;
            Jump();
        }
        */
    }
    /*
    private void OnCollisionEnter(Collision collision)
    {
        collision.GetContacts(contactPoints);
        foreach (ContactPoint contactPoint in contactPoints)
        {
            if (System.Math.Abs(contactPoint.normal.y) > 1e-4f)
            {
                isJumping = false;
                velocity.y = 0.0f;
            }
        }

    }

    private void Jump()
    {
        rigidBody.AddForce(0.0f, jumpSpeed, 0.0f, ForceMode.VelocityChange);
    }
    */
}

