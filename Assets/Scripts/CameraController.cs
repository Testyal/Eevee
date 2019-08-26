using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public GameObject owner;

    public float cameraSpeed;
    public bool isHorizontalCameraReversed;
    public bool isVerticalCameraReversed;

    public float minPitch;
    public float maxPitch;

    private float yaw;
    private float pitch;

    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    // FixedUpdate is called once before each frame's physics update
    void FixedUpdate()
    {
        /* IDEA: Code sockets in suitable objects to plug the camera into */
        transform.position = owner.transform.position + 1.1f* Vector3.up;

        /* Camera */
        pitch += (isVerticalCameraReversed ? 1 : -1) * Input.GetAxis("Mouse Y") * cameraSpeed;
        pitch = Mathf.Clamp(pitch, minPitch, maxPitch);
        yaw += (isHorizontalCameraReversed ? -1 : 1) * Input.GetAxis("Mouse X") * cameraSpeed;

        transform.rotation = Quaternion.Euler(pitch, yaw, 0.0f);
    }
}
