using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Image = UnityEngine.UI.Image;

public class catDrag : MonoBehaviour
{
    [SerializeField] private float maxForce;
    [SerializeField] private float dragCooldown;
    [SerializeField] private float dragDuration = 0;
    [SerializeField] private float maxForceDistance;
    private AudioManager audioManager;
    private float dragDurationTimer;
    private float dragCooldownTimer;
    private bool isAvailable;
    [HideInInspector] public bool isShredded = false;
    private GameObject mousey;
    private float distance;
    private float appliedForce;
    private int estado = 1;
    
    [SerializeField] private Image cDDragBG;
    // Start is called before the first frame update
    void Start()
    {
        mousey = gameObject;

        audioManager = FindFirstObjectByType<AudioManager>();
    }

    // Update is called once per frame
    void Update()
    {
        switch(estado){
            case 1:
                isAvailable = true;
                break;
            case 2:
                dragDurationTimer = dragDuration;
                gameObject.GetComponent<Animator>().SetBool("isGrabbed", true);
                audioManager.Play_catDrag_SFX();
                estado = 3;
                break;
            case 3:
                if (dragDurationTimer > 0) {
                    dragDurationTimer -= Time.deltaTime;
                    //Debug.Log("DURATION LEFT: " + dragDurationTimer);
                }else{
                    isAvailable = false;
                    dragCooldownTimer = dragCooldown;
                    gameObject.GetComponent<Animator>().SetBool("isGrabbed", false);
                    estado = 4;
                }
                break;
            case 4:
                if (dragCooldownTimer > 0){
                    dragCooldownTimer -= Time.deltaTime;
                    cDDragBG.fillAmount = 1-(dragCooldownTimer / dragCooldown);
                    //Debug.Log("COOLDOWN LEFT: " + dragCooldownTimer);
                }else{
                    estado = 1;                    
                }
                break;
        }
    }

    void OnMouseDrag(){
        if (isAvailable && !isShredded){
            if (estado == 1){
                estado = 2;
            }
            var mouseWorldPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            mouseWorldPos.z = 0.0f;
            distance = Vector3.Distance(mouseWorldPos, mousey.transform.position);

            if(dragDurationTimer > 0){
                if (distance > maxForceDistance){
                    appliedForce = maxForce * Time.deltaTime;
                    mousey.transform.position = Vector2.MoveTowards(mousey.transform.position, mouseWorldPos, appliedForce);
                }
                else{
                    appliedForce = (distance / maxForceDistance * maxForce) * Time.deltaTime;
                    mousey.transform.position = Vector2.MoveTowards(mousey.transform.position, mouseWorldPos, appliedForce);
                }
                
            }            
        }
    }
}

