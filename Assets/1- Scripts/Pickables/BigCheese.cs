using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BigCheese : MonoBehaviour
{
    private GameManager gameManager;
    public int scoreGvien = 2;

    // Start is called before the first frame update
    void Start()
    {
        gameManager = FindFirstObjectByType<GameManager>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision != null && collision.CompareTag("Mousey"))
        {
            gameManager.mouseyScore = gameManager.mouseyScore + scoreGvien;
            gameManager.UpdateScore();
            Destroy(gameObject);
        }
    }
}
