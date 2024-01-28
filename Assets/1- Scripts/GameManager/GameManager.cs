using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.PlasticSCM.Editor.WebApi;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.Video;

public class GameManager : MonoBehaviour
{
    [SerializeField] private ItemSpawner itemSpawner;

    [SerializeField] private TextMeshProUGUI healthTxt;
    [SerializeField] private TextMeshProUGUI scoreTxt;
    [SerializeField] private TextMeshProUGUI score2WinTxt;
    public int mouseyScore;
    [SerializeField] private int scoreToWin;

    [SerializeField] private List<Image> mouseyWinScreens = new List<Image>();
    [SerializeField] private List<Image> catWinScreens = new List<Image>();

    [Header("Spawnables")]
    [SerializeField] private GameObject bigCheesePrefab;
    [SerializeField] private GameObject smallCheesePrefab;
    public int smallCheeseConut;
    [SerializeField] private GameObject mysteryBoxPrefab;
    public int mysteryBoxConut;
    public int mystertBoxSpawnRate;

    [Header("Videos")]
    [SerializeField] private VideoPlayer gatoWins;
    [SerializeField] private VideoPlayer mouseyWins;

    [SerializeField] private GameObject uiGameObj;

    [SerializeField] private Texture2D cursorClic;

    void Start()
    {
        itemSpawner = GetComponent<ItemSpawner>();
        mouseyScore = 0;
        smallCheeseConut = 0;
        InvokeRepeating("MysteryBoxSpawner", 0f, mystertBoxSpawnRate);

        itemSpawner.SpawnItems(mysteryBoxPrefab);
        itemSpawner.SpawnItems(mysteryBoxPrefab);
        StartCoroutine(MysteryBoxRespawn());

        score2WinTxt.text = "/ " + scoreToWin.ToString();

    }

    void Update()
    {
        /*
        if(Input.GetMouseButtonDown(0) || Input.GetMouseButtonDown(1)){
            Debug.Log("HOLA");
            Cursor.SetCursor(cursorClic, new Vector2(0, 256), CursorMode.Auto);
        }else{
            Debug.Log("Adios");
            Cursor.SetCursor(null, new Vector2(0, 256), CursorMode.Auto); //null usa el default cursor
        }*/
        while(smallCheeseConut < 5)
        {
            itemSpawner.SpawnItems(smallCheesePrefab);
            smallCheeseConut++;
        }
    }

    public void UpdateHealth(int currentHealth)
    {
        healthTxt.text = "x " + currentHealth.ToString();
    }

    public void UpdateScore()
    {
        scoreTxt.text = "x " + mouseyScore.ToString();

        if(mouseyScore >= scoreToWin)
        {
            OnMouseyWin();
        }
    }

    public void OnMouseyWin()
    {
        uiGameObj.SetActive(false);
        StartCoroutine(WaitAndLoadMenu(mouseyWins,10));

    }

    public void OnCatWin()
    {
        uiGameObj.SetActive(false);

        StartCoroutine(WaitAndLoadMenu(gatoWins,10));
    }


    public IEnumerator WaitAndLoadMenu(VideoPlayer winScreen, float waitTime)
    {
        if(winScreen != null)
        {
            winScreen.Play();
        }

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
