using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShreddedTimer : MonoBehaviour
{
    [SerializeField] private GameObject mousey;
    [SerializeField] private GameObject catCam;
    private float shreddedCooldownTimer;
    private float shreddedDurationTimer;
    [SerializeField] private float shreddedCooldown = 10.0f;
    [SerializeField] private float shreddedDuration = 30.0f;
    private int estado = 1;
    private CatCheesyManager cat;
    void Start()
    {
        cat = FindFirstObjectByType<CatCheesyManager>();
        shreddedCooldownTimer = shreddedCooldown;
    }

    // Update is called once per frame
    void Update()
    {
        switch(estado){
            case 1:
                if(shreddedCooldownTimer >= 0){
                    shreddedCooldownTimer -= Time.deltaTime;
                    //Debug.Log("DURATION LEFT: " + shreddedCooldownTimer);
                }else{
                    estado = 2;
                }
                break;
            case 2:
                mousey.GetComponent<catDrag>().isShredded = true;
                catCam.GetComponent<CatBomb>().isShredded = true;
                shreddedDurationTimer = shreddedDuration;
                cat.Syringe();
                estado = 3;
                break;
            case 3:
                if(shreddedDurationTimer >= 0){
                    shreddedDurationTimer -= Time.deltaTime;
                    //Debug.Log("DURATION LEFT: " + shreddedDurationTimer);
                }else{
                    estado = 4;
                }
                break;
            case 4:
                mousey.GetComponent<catDrag>().isShredded = false;
                catCam.GetComponent<CatBomb>().isShredded = false;
                shreddedCooldownTimer = shreddedCooldown;
                cat.ShreddedOff();
                estado = 1;
                break;
        }
    }
}
