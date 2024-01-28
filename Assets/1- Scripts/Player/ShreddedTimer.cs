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
    [SerializeField] private GameObject cat;
    [SerializeField] private GameObject transitionBox;
    private Animator animCat;
    
    [SerializeField] private GameObject BomButton;
    [SerializeField] private GameObject DragButton;
    [SerializeField] private GameObject SuperBomButton;
    [SerializeField] private GameObject BoxButton;
    void Start()
    {
        animCat = cat.GetComponent<Animator>();
        shreddedCooldownTimer = shreddedCooldown;
        DragButton.SetActive(true);
        BomButton.SetActive(true);
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
                animCat.SetTrigger("Syringe");
                StartCoroutine(CatTransition());
                animCat.SetBool("isShredded", true);
                shreddedDurationTimer = shreddedDuration;
                estado = 3;
                DragButton.SetActive(false);
                BomButton.SetActive(false);
                SuperBomButton.SetActive(true);
                BoxButton.SetActive(true);
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
                animCat.SetBool("isShredded", false);
                shreddedCooldownTimer = shreddedCooldown;
                estado = 1;
                DragButton.SetActive(true);
                BomButton.SetActive(true);
                SuperBomButton.SetActive(false);
                BoxButton.SetActive(false);
                break;
        }
    }

    private IEnumerator CatTransition()
    {
        
        yield return new WaitForSeconds(7/5);

        transitionBox.GetComponent<Animator>().SetTrigger("Transition");
    }
}
