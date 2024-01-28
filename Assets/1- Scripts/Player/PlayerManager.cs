using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Net.NetworkInformation;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;
using Debug = System.Diagnostics.Debug;

public class PlayerManager : MonoBehaviour
{
    [SerializeField] private float playerSpeed;
    [SerializeField] private float movCooldown;
    [SerializeField] private LayerMask walls;
    [SerializeField] private LayerMask nothingLayer;
    private Vector3 nextPosition;
    private GameManager gameManager;

    private bool isMoving;

    public int health = 0;

    public bool isInvincible = false;
    public float invincibleTimer;
    public float timeInvincible = 2.0f;
    public float ghostTimer;
    public float timeGhost = 4.0f;
    public bool isGhost = false;


    [SerializeField] private ParticleSystem takeDamageVFX;

    [SerializeField] private GameObject cat;
    private Animator animCat;
    private AudioManager audioManager;


    void Start()
    {
        gameManager = FindFirstObjectByType<GameManager>();
        animCat = cat.GetComponent<Animator>();
        isMoving = false;
        health = 7;
        isInvincible = false;
        isGhost = false;

        gameManager.UpdateHealth(health);
        audioManager = FindFirstObjectByType<AudioManager>();


    }

    private void Update()
    {
        if (isInvincible)
        {

            invincibleTimer -= Time.deltaTime;
            if (invincibleTimer < 0)
            {
                isInvincible = false;
                invincibleTimer = timeInvincible;
            }
        }

        if (isGhost)
        {
            UnityEngine.Debug.Log("Ghosting Happening");
            gameObject.GetComponent<CircleCollider2D>().excludeLayers = walls;
            ghostTimer -= Time.deltaTime;
            if (ghostTimer < 0)
            {
                isGhost = false;
                ghostTimer = timeGhost;
                gameObject.GetComponent<CircleCollider2D>().excludeLayers = nothingLayer;
            }
        }

        
    }

    void FixedUpdate()
    {
        if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.D))
        {
            CheckMovement();
        }
        else
        {
            isMoving = false;
            gameObject.GetComponent<Animator>().SetBool("isMoving", isMoving);
        }
    }

    private void CheckMovement()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        isMoving = true;

        Vector3 movement = new Vector3(horizontalInput, verticalInput, 0f) * playerSpeed * Time.fixedDeltaTime;
        //UnityEngine.Debug.Log(movement);
        gameObject.GetComponent<Animator>().SetBool("isMoving", isMoving);
        gameObject.GetComponent<Animator>().SetFloat("MoveX", movement.x / (playerSpeed * movCooldown));
        gameObject.GetComponent<Animator>().SetFloat("MoveY", movement.y / (playerSpeed * movCooldown));
        transform.Translate(movement);
    }

    private Vector3 AproximatePosition()
    {
        // Aqu� es donde se usa el m�todo math.round para redondear a el n�mero entero m�s cercano

        Vector3 currentPos = gameObject.transform.position;
        Vector3 aproximatePos = new Vector3(math.round(currentPos.x),math.round(currentPos.y));

        return aproximatePos;
    }

    public void TakeDamage(int amount)
    {
        if (isInvincible)
            return;


        isInvincible = true;
        gameObject.GetComponent<Animator>().SetTrigger("Damaged");
        invincibleTimer = timeInvincible;

        animCat.SetTrigger("Happy"); 
        health -= amount;
        if (health <= 0)
        {
            //MOUSEY SE PETATEO, PONGAN LA ANIMACION
            gameManager.OnCatWin();
        }

        takeDamageVFX.Play();
        audioManager.Play_mouseHurt_SFX();
        gameManager.UpdateHealth(health);
    }
}
