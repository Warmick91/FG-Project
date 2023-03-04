using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PivotRotator : MonoBehaviour
{
    [SerializeField]
    float rotationSpeed = 100.0f;

    void Update()
    {
        RotatePivot();
    }

    void RotatePivot()
    {
        transform.Rotate(Vector3.up * Time.deltaTime * rotationSpeed);
    }

}
