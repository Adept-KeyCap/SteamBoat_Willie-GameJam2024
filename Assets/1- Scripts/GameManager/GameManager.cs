using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.PlasticSCM.Editor.WebApi;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private ItemSpawner itemSpawner;
    [SerializeField] private GameObject prefab1;

    [SerializeField] private TextMeshProUGUI healthTxt;
    [SerializeField] private TextMeshProUGUI scoreTxt;

    void Start()
    {
        itemSpawner = GetComponent<ItemSpawner>();
    }

    void Update()
    {
        
    }

    public void UpdateHealth(int currentHealth)
    {
        healthTxt.text = currentHealth.ToString();
    }

    public void UpdateScore(int currentScore)
    {
        scoreTxt.text = currentScore.ToString();
    }
}
