using UnityEngine;
using Unity.Mathematics;

public class CatBomb : MonoBehaviour
{
    [SerializeField] private GameObject bomb;
    [SerializeField] private GameObject box;
    [SerializeField] private GameObject bombom;// Assign your prefab in the Inspector
    [SerializeField] private float firerate;
    [SerializeField] private float boxFirerate;
    private float timer;
    private float boxTimer;
    public LayerMask wallLayer;
    public bool isShredded = false;

    private void Start()
    {
        timer = firerate;
        boxTimer = boxFirerate;
    }
    void Update()
    {
        timer -= Time.deltaTime;
        boxTimer -= Time.deltaTime;

        if (timer < 0 && Input.GetMouseButtonDown(1))
        {
            Vector3 mousePosition = Input.mousePosition;
            mousePosition.z = 10f; // Set this to be the distance you want the object to be placed in front of the camera
            Vector3 worldPosition = Camera.main.ScreenToWorldPoint(mousePosition);
            //Debug.Log(IsOverlappingWithObstacles(worldPosition, wallLayer));
            if (!IsOverlappingWithObstacles(worldPosition, wallLayer)) // Right click
            {               
                if (isShredded)
                {
                    Instantiate(bombom, worldPosition, Quaternion.identity);
                }
                else
                {
                    Instantiate(bomb, worldPosition, Quaternion.identity);
                }
            }

            timer = firerate;
        }

        if (boxTimer < 0 && Input.GetMouseButtonDown(0))
        {
            Vector3 mousePosition = Input.mousePosition;
            mousePosition.z = 10f; // Set this to be the distance you want the object to be placed in front of the camera
            Vector3 worldPosition = Camera.main.ScreenToWorldPoint(mousePosition);

            if (!IsOverlappingWithObstacles(worldPosition, wallLayer) && isShredded) // Right click
            {
                Instantiate(box, worldPosition, Quaternion.identity);
            }

            boxTimer = boxFirerate;
        }

    }

    bool IsOverlappingWithObstacles(Vector2 position, LayerMask currentLayer)
    {
        // Check if there are any colliders at the specified position
        Collider2D[] colliders = Physics2D.OverlapCircleAll(position, 0.5f, currentLayer);

        // If there are no colliders, return false (no overlap)
        return colliders.Length > 0;
    }

    private Vector3 AproximatePosition(Vector3 currentPosition)
    {
        // Aqu� es donde se usa el m�todo math.round para redondear a el n�mero entero m�s cercano

        Vector3 aproximatePos = new Vector3(math.round(currentPosition.x), math.round(currentPosition.y));

        return aproximatePos;
    }
}
