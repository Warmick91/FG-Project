using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnBall : MonoBehaviour
{
    public GameObject ballPrefab;
    public SphereCollider spawnArea;
    public SphereCollider excludeArea;
    const float positionY = 0.5f;

    

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Vector3 randomPosition;
            bool insideExcludedArea = false;

            // Generate random positions until one that is outside the excluded area is found
            do
            {
                randomPosition = new Vector3(
                    Random.Range(spawnArea.bounds.min.x, spawnArea.bounds.max.x),
                    positionY,
                    Random.Range(spawnArea.bounds.min.z, spawnArea.bounds.max.z)
                );

                // If the generated position IS NOT within the excluded area, change the variable's value to true and break the loop
                insideExcludedArea = excludeArea.bounds.Contains(randomPosition);

            } while (insideExcludedArea);


            Instantiate(ballPrefab, randomPosition, Quaternion.identity);
        }
    }
}
