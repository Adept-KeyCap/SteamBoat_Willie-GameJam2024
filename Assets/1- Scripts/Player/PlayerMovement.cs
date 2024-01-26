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

    private Vector3 w = new Vector2(0, 1);
    private Vector3 w_a = new Vector2(-1, 1);
    private Vector3 a = new Vector2(-1, 0);
    private Vector3 a_s = new Vector2(-1, -1);
    private Vector3 s = new Vector2(0, -1);
    private Vector3 s_d = new Vector2(1, -1);
    private Vector3 d = new Vector2(1, 0);
    private Vector3 d_w = new Vector2(1, 1);

    private Vector3 nextPosition;

    private bool canMove; 

    // Start is called before the first frame update
    void Start()
    {
        canMove = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (canMove)
        {
            CheckMovement();
        }
    }

    private void CheckMovement()
    {
        if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.D))
        {
            if(Input.GetKey(KeyCode.W) && Input.GetKey(KeyCode.A))
            {
                UpdateMovement(w_a);
            }
            else if (Input.GetKey(KeyCode.A) && Input.GetKey(KeyCode.S))
            {
                UpdateMovement(a_s);
            }
            else if (Input.GetKey(KeyCode.W) && Input.GetKey(KeyCode.D))
            {
                UpdateMovement(d_w);
            }
            else if (Input.GetKey(KeyCode.S) && Input.GetKey(KeyCode.D))
            {
                UpdateMovement(s_d);
            }
            else if (Input.GetKey(KeyCode.W))
            {
                UpdateMovement(w);
            }
            else if (Input.GetKey(KeyCode.A))
            {
                UpdateMovement(a);
            }
            else if (Input.GetKey(KeyCode.D))
            {
                UpdateMovement(d);
            }
            else if (Input.GetKey(KeyCode.S))
            {
                UpdateMovement(s);
            }
        }
    }

    private void UpdateMovement(Vector3 direction)
    {
        nextPosition = gameObject.transform.position + direction;
        
        StartCoroutine(MovementCooldown(movCooldown));
    }

    private IEnumerator MovementCooldown(float cooldown)
    {
        float elapsedTime = 0f;

        canMove = false;

        while (elapsedTime < cooldown)
        {
            gameObject.transform.position = Vector3.Lerp(gameObject.transform.position, nextPosition, elapsedTime / cooldown);

            elapsedTime += Time.fixedDeltaTime;
            yield return null;
        }
        
        gameObject.transform.position = AproximatePosition();
        canMove = true;
    }

    private Vector3 AproximatePosition()
    {

        // Aquí es donde se usa el método math.round para redondear a el número entero más cercano

        Vector3 currentPos = gameObject.transform.position;
        Vector3 aproximatePos = new Vector3(math.round(currentPos.x),math.round(currentPos.y));

        return aproximatePos;
    }
}
