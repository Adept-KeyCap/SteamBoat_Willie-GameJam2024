using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BigCheese : MonoBehaviour
{
    private GameManager gameManager;
    public int scoreGvien = 2;

    private AudioManager audioManager;
    // Start is called before the first frame update
    void Start()
    {
        gameManager = FindFirstObjectByType<GameManager>();
        audioManager = FindFirstObjectByType<AudioManager>();

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision != null && collision.CompareTag("Mousey"))
        {
            audioManager.Play_cheeseChomp_SFX();


            gameManager.mouseyScore = gameManager.mouseyScore + scoreGvien;
            gameManager.UpdateScore();
            Destroy(gameObject);
        }
    }
}
