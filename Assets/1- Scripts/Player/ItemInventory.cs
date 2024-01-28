using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemInventory : MonoBehaviour
{
    [HideInInspector] public int status = 0;
    public GameObject redCheese;

    private PlayerManager player;
    private ItemSpawner spawner;

    [SerializeField] private GameObject itemHolder;
    [SerializeField] private Sprite invincible; 
    [SerializeField] private Sprite redCheeze; 
    [SerializeField] private Sprite phantom; 
    [SerializeField] private Sprite blank; 
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
                    itemHolder.GetComponent<Image>().sprite = blank;
                    status = 0;
                }
                break;
            case 2 :
                if (Input.GetKeyDown(KeyCode.Space))
                {
                    Debug.Log("Ghost mode power up pressed");
                    player.isGhost = true;
                    player.ghostTimer = 4f;
                    itemHolder.GetComponent<Image>().sprite = blank;
                    status = 0;
                }
                break;
            case 3 :
                if (Input.GetKeyDown(KeyCode.Space))
                {
                    spawner.SpawnItems(redCheese);
                    Debug.Log("Red Cheese power up pressed");
                    itemHolder.GetComponent<Image>().sprite = blank;
                    status = 0;
                }
                break;
            default:
                Debug.Log("default NODEBERIAPASAR power up pressed");
                status = 0;
                break;
        }
    }

    public void updateIcon(int icon){
        switch(icon){
            case 1:
                itemHolder.GetComponent<Image>().sprite = invincible;
                break;

            case 2:
                itemHolder.GetComponent<Image>().sprite = phantom;
                break;
            
            case 3:
                itemHolder.GetComponent<Image>().sprite = redCheeze;

                break;
        }
    }
}
