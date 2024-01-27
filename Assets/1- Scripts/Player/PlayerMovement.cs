using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Net.NetworkInformation;
using Unity.Mathematics;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float playerSpeed;
    [SerializeField] private float movCooldown;

    private Vector3 nextPosition;

    private bool isMoving; 

    void Start()
    {
        isMoving = false;
    }

    void FixedUpdate()
    {
        if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.D))
        {
            CheckMovement();
        }
        else
        {
            nextPosition = AproximatePosition();
            gameObject.transform.position = Vector3.Lerp(gameObject.transform.position, nextPosition, 2);
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
        // Aquí es donde se usa el método math.round para redondear a el número entero más cercano

        Vector3 currentPos = gameObject.transform.position;
        Vector3 aproximatePos = new Vector3(math.round(currentPos.x),math.round(currentPos.y));

        return aproximatePos;
    }
}
