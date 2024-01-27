using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private ItemSpawner itemSpawner;
    [SerializeField] private GameObject prefab1;

    void Start()
    {
        itemSpawner = GetComponent<ItemSpawner>();
    }

    void Update()
    {
        
    }

}
