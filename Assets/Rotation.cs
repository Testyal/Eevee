using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotation : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float deltaAngle = 10.0f * Time.deltaTime; // 10.0f degrees/s
        transform.Rotate(0.0f, deltaAngle, 0.0f);
    }
}
