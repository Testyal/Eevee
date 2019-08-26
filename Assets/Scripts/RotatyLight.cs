using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotatyLight : MonoBehaviour
{
    /* Rate of change of angle in degrees/s */
    public Vector3 deltaRotation = new Vector3(0.0f, 45.0f, 0.0f);

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(deltaRotation * Time.deltaTime, Space.World);
    }
}
