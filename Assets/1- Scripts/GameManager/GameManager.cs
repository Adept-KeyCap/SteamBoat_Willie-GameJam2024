using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.PlasticSCM.Editor.WebApi;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField] private ItemSpawner itemSpawner;

    [SerializeField] private TextMeshProUGUI healthTxt;
    [SerializeField] private TextMeshProUGUI scoreTxt;  
    public int mouseyScore;

    [SerializeField] private List<Image> mouseyWinScreens = new List<Image>();
    [SerializeField] private List<Image> catWinScreens = new List<Image>();

    [Header("Spawnables")]
    [SerializeField] private GameObject bigCheesePrefab;
    [SerializeField] private GameObject smallCheesePrefab;
    public int smallCheeseConut;
    [SerializeField] private GameObject mysteryBoxPrefab;
    public int mysteryBoxConut;
    public int mystertBoxSpawnRate;

    void Start()
    {
        itemSpawner = GetComponent<ItemSpawner>();
        mouseyScore = 0;
        smallCheeseConut = 0;
        InvokeRepeating("MysteryBoxSpawner", 0f, mystertBoxSpawnRate);

        itemSpawner.SpawnItems(mysteryBoxPrefab);
        itemSpawner.SpawnItems(mysteryBoxPrefab);
        StartCoroutine(MysteryBoxRespawn());

    }

    void Update()
    {
        while(smallCheeseConut < 5)
        {
            itemSpawner.SpawnItems(smallCheesePrefab);
            smallCheeseConut++;
        }

    }

    public void UpdateHealth(int currentHealth)
    {
        healthTxt.text = currentHealth.ToString();
    }

    public void UpdateScore()
    {
        scoreTxt.text = mouseyScore.ToString();
    }

    public void OnMouseyWin()
    {

        StartCoroutine(WaitAndLoadMenu(5));

    }

    public void OnCatWin()
    {

        StartCoroutine(WaitAndLoadMenu(5));
    }


    public IEnumerator WaitAndLoadMenu(float waitTime)
    {


        yield return new WaitForSeconds(waitTime);

        SceneManager.LoadScene(0);
    }


    private IEnumerator MysteryBoxRespawn()
    {
        itemSpawner.SpawnItems(mysteryBoxPrefab);
        Debug.Log("A Mystery Box Spawns");

        yield return new WaitForSeconds(mystertBoxSpawnRate);

        StartCoroutine(MysteryBoxRespawn());
    }
}
