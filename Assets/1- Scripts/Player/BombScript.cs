using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombScript : MonoBehaviour
{
    [SerializeField] private float bombTimerDuration;
    //[SerializeField] private float dragDuration = 0;
    [SerializeField] private GameObject explosionArea;
    private float bombTimer;
    //private float dragCooldownTimer;
    //private bool isAvailable;

    // Start is called before the first frame update
    void Start()
    {
        explosionArea.SetActive(false);
        bombTimer = bombTimerDuration;
    }

    // Update is called once per frame
    void Update()
    {
        bombTimer -= Time.deltaTime;

        if (bombTimer < 0)
        {
            explosionArea.SetActive(true);

            //this.gameObject.SetActive(false);
            //Destroy(this.gameObject);
        }
    }
}
