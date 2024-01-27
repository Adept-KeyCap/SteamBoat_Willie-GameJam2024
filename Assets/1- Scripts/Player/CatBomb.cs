using UnityEngine;
using Unity.Mathematics;

public class CatBomb : MonoBehaviour
{
    [SerializeField] private GameObject bomb;
    [SerializeField] private GameObject bombom;// Assign your prefab in the Inspector
    [SerializeField] private float bombCD;
    [SerializeField] private float boxCD;
    private float bombTimer;
    private float boxTimer;
    public LayerMask wallLayer;
    public bool isShredded = false;

    private void Start()
    {
        bombTimer = bombCD;
        boxTimer = boxCD;
    }
    void Update()
    {
        bombTimer -= Time.deltaTime;
        if (bombTimer < 0 && Input.GetMouseButtonDown(1))
        {
            Vector3 mousePosition = Input.mousePosition;
            mousePosition.z = 10f; // Set this to be the distance you want the object to be placed in front of the camera
            Vector3 worldPosition = Camera.main.ScreenToWorldPoint(mousePosition);
            Debug.Log(IsOverlappingWithObstacles(worldPosition, wallLayer));
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

            bombTimer = bombCD;
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
        // Aquí es donde se usa el método math.round para redondear a el número entero más cercano

        Vector3 aproximatePos = new Vector3(math.round(currentPosition.x), math.round(currentPosition.y));

        return aproximatePos;
    }
}
