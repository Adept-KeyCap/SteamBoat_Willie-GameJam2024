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

    [SerializeField] private List<Image> mouseyWinScreens = new List<Image>();
    [SerializeField] private List<Image> catWinScreens = new List<Image>();

    private int mouseyScore;

    void Start()
    {
        itemSpawner = GetComponent<ItemSpawner>();
        mouseyScore = 0;
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
}
