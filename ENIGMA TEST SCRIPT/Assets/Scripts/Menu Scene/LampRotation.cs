using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LampRotation : MonoBehaviour
{
    float MaxAngle = 8;
    float MinAngle = -8;
    public float _rotationSpeed = 2.75F;

    bool _moveOnRight = true;

    void Update()
    {
        RotationTime();
    }

    void RotationTime()
    {
        if (_moveOnRight)
        {
            transform.rotation = Quaternion.Euler(0.0f, 0.0f, MaxAngle * Mathf.Sin(Time.time * _rotationSpeed));
        }
        else
        {
            transform.rotation = Quaternion.Euler(0.0f, 0.0f, MinAngle * Mathf.Sin(Time.time * _rotationSpeed));
        }

        if (transform.rotation.z > MaxAngle) _moveOnRight = false;

        if (transform.rotation.z < MinAngle) _moveOnRight = true;
    }
}
