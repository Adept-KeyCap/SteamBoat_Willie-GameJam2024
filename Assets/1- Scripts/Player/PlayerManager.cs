using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Net.NetworkInformation;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

public class PlayerManager : MonoBehaviour
{
    [SerializeField] private float playerSpeed;
    [SerializeField] private float movCooldown;

    private Vector3 nextPosition;

    private bool isMoving;

    public int health = 0;
    public bool isInvincible = false;
    public float invincibleTimer;
    public float timeInvincible = 2.0f;
    
    void Start()
    {
        isMoving = false;
        health = 5;
        isInvincible = false;
    }

    private void Update()
    {
        if (isInvincible)
        {

            invincibleTimer -= Time.deltaTime;
            if (invincibleTimer < 0)
            {
                isInvincible = false;

            }
        }
    }

    void FixedUpdate()
    {
        if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.D))
        {
            CheckMovement();
        }
    }

    private void CheckMovement()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        isMoving = true;

        Vector3 movement = new Vector3(horizontalInput, verticalInput, 0f) * playerSpeed * Time.fixedDeltaTime;
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
            invincibleTimer = timeInvincible;

            
            health -= amount;
            if (health <= 0)
            {
                //MOUSEY SE PETATEO, PONGAN LA ANIMACION
            }
    }
}
