using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class ItemInventory : MonoBehaviour
{
    [HideInInspector] public int status = 0;
    public GameObject redCheese;

    private PlayerManager player;
    private ItemSpawner spawner;

    [SerializeField] private SpriteRenderer mouseySprite;
    private Color ghostColor;

    [SerializeField] private GameObject itemHolder;
    [SerializeField] private Sprite invincible; 
    [SerializeField] private Sprite redCheeze; 
    [SerializeField] private Sprite phantom; 
    [SerializeField] private Sprite blank;
    // Start is
    // called before the first frame update
    [SerializeField] private ParticleSystem cantTouchMe;
    [SerializeField] private GameObject fireVFXobj;
    [SerializeField] private ParticleSystem maxDefense;
    private AudioManager audioManager;

    void Start()
    {
        player = FindFirstObjectByType<PlayerManager>();
        status = 0;
        spawner = FindFirstObjectByType<ItemSpawner>();
        audioManager = FindFirstObjectByType<AudioManager>();
        itemHolder.SetActive(false);
        mouseySprite = GetComponent<SpriteRenderer>();
        ghostColor = new Color(0, 255, 255, 130);

        cantTouchMe.gameObject.SetActive(false);

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
                    StartCoroutine(InvincibleVFX());
                    player.isInvincible = true;
                    audioManager.Play_invincibility_SFX();
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
                    StartCoroutine(PhantomVFX());

                    audioManager.Play_phantom_SFX();
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
                    audioManager.Play_redCheese_SFX();
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
        itemHolder.SetActive(true);

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

    IEnumerator PhantomVFX()
    {
        fireVFXobj.SetActive(true);
        cantTouchMe.Play();
        audioManager.Play_phantom_SFX();
        mouseySprite.color = ghostColor;
        yield return new WaitForSeconds(2);
        mouseySprite.color = Color.white;

        cantTouchMe.Stop();
        fireVFXobj.SetActive(false);

    }

    IEnumerator InvincibleVFX()
    {
        maxDefense.Play();

        yield return new WaitForSeconds(4);

        maxDefense.Stop();

    }

}
