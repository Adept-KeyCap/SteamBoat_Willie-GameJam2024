using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SmallCheese : MonoBehaviour
{
    private GameManager gameManager;

    // Start is called before the first frame update
    void Start()
    {
        gameManager = FindFirstObjectByType<GameManager>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision != null && collision.CompareTag("Mousey"))
        {
            gameManager.smallCheeseConut--;
            gameManager.mouseyScore++;
            gameManager.UpdateScore();
            Destroy(gameObject);
        }
    }
}
