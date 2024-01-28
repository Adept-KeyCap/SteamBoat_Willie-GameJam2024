using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CatCheesyManager : MonoBehaviour
{
    public int status = 0;

    private PlayerManager player;
    // Start is called before the first frame update
    void Start()
    {
        player = FindFirstObjectByType<PlayerManager>();
        status = 0;
    }

    // Update is called once per frame
    void Update()
    {
        switch (status)
        {
            case 0:
                break;
            case 1:
                break;
            case 2:
                break;
            case 3:
                break;
            case 4:
                break;
            case 5:
                break;
            default:
                break;
        }
    }
}
