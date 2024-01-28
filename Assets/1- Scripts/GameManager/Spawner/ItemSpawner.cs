using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class ItemSpawner : MonoBehaviour
{
    [SerializeField] private BoxCollider2D spawnCollider;

    public LayerMask wallsLayer;
    public LayerMask itemsLayer;

    private Vector2 minSpawnArea;
    private Vector2 maxSpawnArea;

    private int maxIterations = 10;

    private void Awake() {
        minSpawnArea = spawnCollider.bounds.min;
        maxSpawnArea = spawnCollider.bounds.max;
    }

    public void SpawnItems(GameObject prefab)
    {
        int spawnIterations = 0;

        while(spawnIterations < maxIterations)
        {
            Vector2 randomPos = GetRandomPosition();

            if(!IsOverlappingWithObstacles(randomPos, wallsLayer) && !IsOverlappingWithObstacles(randomPos, itemsLayer))
            {
                Instantiate(prefab, AproximatePosition(randomPos), Quaternion.identity);

                break;
            }

            spawnIterations++;
        }
    }

    private Vector2 GetRandomPosition()
    {
       
        float randomX = UnityEngine.Random.Range(minSpawnArea.x, maxSpawnArea.x);
        float randomY = UnityEngine.Random.Range(minSpawnArea.y, maxSpawnArea.y);
        spawnCollider.enabled = false;
        return new Vector2(randomX, randomY);
    }


    bool IsOverlappingWithObstacles(Vector2 position, LayerMask currentLayer)
    {
        // Check if there are any colliders at the specified position
        Collider2D[] colliders = Physics2D.OverlapCircleAll(position, 0.5f, currentLayer);

        // If there are no colliders, return false (no overlap)
        return colliders.Length > 0;
    }

    private Vector3 AproximatePosition(Vector3 currentPosition)
    {
        // Aqu� es donde se usa el m�todo math.round para redondear a el n�mero entero m�s cercano

        Vector3 aproximatePos = new Vector3(math.round(currentPosition.x), math.round(currentPosition.y));

        return aproximatePos;
    }
}
