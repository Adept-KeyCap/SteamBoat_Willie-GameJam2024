using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class PowerUp : MonoBehaviour
{

    private int selected = 0;

    private ItemInventory inventory;
    private AudioManager audioManager;


    // Start is called before the first frame update
    void Start()
    {
       selected = Random.Range(1, 4);
       inventory = FindFirstObjectByType<ItemInventory>();
       audioManager = FindFirstObjectByType<AudioManager>();

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Mousey")
        {
            switch (selected)
            {
            case 1:
                inventory.status = 1;
                inventory.updateIcon(1);
                Debug.Log("Power 1");
                Destroy(gameObject);
                break;
            case 2:
                inventory.status = 2;
                inventory.updateIcon(2);
                Debug.Log("Power 2");
                Destroy(gameObject);
                break;
            case 3:
                inventory.status = 3;
                inventory.updateIcon(3);
                Debug.Log("Power 3");
                Destroy(gameObject);
                break;
            default:
                Debug.Log("El Random no dio");
                Destroy(gameObject);
                break;
            }

            audioManager.Play_mysteryBox_SFX();
        }
        
    }
}
