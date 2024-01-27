using UnityEngine;

public class CatBomb : MonoBehaviour
{
    [SerializeField] private GameObject prefab; // Assign your prefab in the Inspector
    [SerializeField] private float firerate;
    private float timer;

    private void Start()
    {
        timer = firerate;
    }
    void Update()
    {
        timer -= Time.deltaTime;
        if (timer < 0 && Input.GetMouseButtonDown(1))
        {
            //if (Input.GetMouseButtonDown(1)) // Right click
            //{
                Vector3 mousePosition = Input.mousePosition;
                mousePosition.z = 10f; // Set this to be the distance you want the object to be placed in front of the camera
                Vector3 worldPosition = Camera.main.ScreenToWorldPoint(mousePosition);

                Instantiate(prefab, worldPosition, Quaternion.identity);
            //}

            timer = firerate;
        }       
    }
}
