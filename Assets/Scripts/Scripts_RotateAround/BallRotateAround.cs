using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BallRotateAround : MonoBehaviour

{
    public Transform cube;
    public float rotationSpeed = 50.0f;

    void Start()
    {
        cube = GameObject.Find("Cube").GetComponent<Transform>();
    }

    void Update()
    {   
        // Rotate around the cube
        transform.RotateAround(cube.position, Vector3.up, rotationSpeed * Time.deltaTime);
    }
}