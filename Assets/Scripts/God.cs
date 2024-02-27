using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class God : MonoBehaviour
{
    [SerializeField] private float rotationSpeedX = 1f, rotationSpeedY = 1f, rotationSpeedZ = 1f;

    private void FixedUpdate()
    {
        RotateOverTime();
    }

    private void RotateOverTime()
    {
        transform.Rotate(rotationSpeedX, rotationSpeedY, rotationSpeedZ);
    }
}
