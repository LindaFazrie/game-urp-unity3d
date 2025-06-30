using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotationCoin : MonoBehaviour
{
    [Header("Rotation Settings")]
    public float rotationSpeed = 100f; // kecepatan mutarnya (bisa diatur di Inspector)

    void Update()
    {
        transform.Rotate(Vector3.up, rotationSpeed * Time.deltaTime);
    }
}
