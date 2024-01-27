using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemSpawner : MonoBehaviour
{
    [SerializeField] private BoxCollider2D spawnCollider;

    public LayerMask wallsLayer;

    private int maxIterations = 10;

    public void SpawnItems(GameObject prefab)
    {
        int spawnIterations = 0;


        while(spawnIterations < maxIterations)
        {
            Vector2 randomPos = GetRandomPosition();

            Debug.Log(IsOverlappingWithObstacles(randomPos));

            if(!IsOverlappingWithObstacles(randomPos))
            {
                Instantiate(prefab, randomPos, Quaternion.identity);

                break;
            }

            spawnIterations++;
        }
    }

    private Vector2 GetRandomPosition()
    {
        Vector2 maxSpawnArea = spawnCollider.bounds.max;
        Vector2 centerSpawnArea = spawnCollider.bounds.center;

        float randomx = UnityEngine.Random.Range(maxSpawnArea.x, centerSpawnArea.x);
        float randomy = UnityEngine.Random.Range(maxSpawnArea.y, centerSpawnArea.y);

        return new Vector2(randomx, randomy);
    }

    bool IsOverlappingWithObstacles(Vector2 position)
    {
        // Check if there are any colliders at the specified position
        Collider2D[] colliders = Physics2D.OverlapCircleAll(position, 0.5f, wallsLayer);

        // If there are no colliders, return false (no overlap)
        return colliders.Length > 0;
    }
}
