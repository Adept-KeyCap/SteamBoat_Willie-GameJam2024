using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SmallCheese : MonoBehaviour
{
    private GameManager gameManager;
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

            gameManager.smallCheeseConut--;
            gameManager.mouseyScore++;
            gameManager.UpdateScore();
            Destroy(gameObject);
        }
    }
}
