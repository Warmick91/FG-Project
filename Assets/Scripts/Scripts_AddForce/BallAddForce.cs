using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallAddForce : MonoBehaviour
{
    private Rigidbody ballRb;
    private GameObject cube;
    private Vector3 directionBallToCube;
    private Vector3 directionRound;
    private float rollSpeed = 250.0f;

    void Start()
    {
        ballRb = GetComponent<Rigidbody>();
        cube = GameObject.Find("Cube");
    }

    void FixedUpdate()
    {
        // Calculate a vector towards the cube
        directionBallToCube = (cube.transform.position - this.transform.position).normalized;
    
        // Calculate the perpendicular vector
        directionRound = Vector3.Cross(directionBallToCube, Vector3.up);
        ballRb.AddForce(directionRound * rollSpeed * Time.deltaTime);
        ballRb.AddForce(directionBallToCube * rollSpeed * Time.deltaTime);
    }


}
