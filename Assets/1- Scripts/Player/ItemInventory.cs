using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemInventory : MonoBehaviour
{
    public int status = 0;
    public GameObject redCheese;

    private PlayerManager player;
    private ItemSpawner spawner;
    // Start is called before the first frame update
    void Start()
    {
        player = FindFirstObjectByType<PlayerManager>();
        status = 0;
        spawner = FindFirstObjectByType<ItemSpawner>();
    }

    // Update is called once per frame
    void Update()
    {
        switch (status)
        {
            case 0 : //null
                break;
            case 1 :
                if (Input.GetKeyDown(KeyCode.Space))
                {
                    Debug.Log("invincible power up pressed");
                    player.isInvincible = true;
                    player.invincibleTimer = 4f;

                    status = 0;
                }
                break;
            case 2 :
                if (Input.GetKeyDown(KeyCode.Space))
                {
                    Debug.Log("Ghost mode power up pressed");
                    status = 0;
                }
                break;
            case 3 :
                if (Input.GetKeyDown(KeyCode.Space))
                {
                    spawner.SpawnItems(redCheese);
                    Debug.Log("Red Cheese power up pressed");
                    status = 0;
                }
                break;
            default:
                Debug.Log("default NODEBERIAPASAR power up pressed");
                status = 0;
                break;
        }
    }
}
