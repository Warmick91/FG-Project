using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnBall : MonoBehaviour
{
    public GameObject ballPrefab;
    public SphereCollider spawnArea;
    public SphereCollider excludedArea;
    const float positionY = 0.5f;

    ColorSwitcher colorSwitcher;

    void Awake()
    {
        GameObject cube = GameObject.Find("Cube");
        if (cube != null) colorSwitcher = cube.GetComponent<ColorSwitcher>();
        else Debug.LogError("Could not find the 'Cube' game object");
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Vector3 randomPosition;
            bool insideExcludeArea = false;

            // Generate random positions until one that is outside the excluded area is found
            do
            {
                randomPosition = new Vector3(
                    Random.Range(spawnArea.bounds.min.x, spawnArea.bounds.max.x),
                    positionY,
                    Random.Range(spawnArea.bounds.min.z, spawnArea.bounds.max.z)
                );

                // If randomPosition IS NOT within the excluded area, change the variable's value to True and break the loop
                insideExcludeArea = excludedArea.bounds.Contains(randomPosition);
            }
            while (insideExcludeArea);

            // Instantiate a new ball at the random position
            GameObject newBall = Instantiate(ballPrefab, randomPosition, Quaternion.identity);
            newBall.GetComponent<MeshRenderer>().material.color = colorSwitcher.CreateNewColor();
        }
    }
}