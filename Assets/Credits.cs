using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Credits : MonoBehaviour
{
    private void Start()
    {
        StartCoroutine(LoadpreviosScene());
    }

    void FixedUpdate()
    {
        gameObject.transform.position = gameObject.transform.position + new Vector3(0, 1f, 0);

        if (Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.Escape))
        {
            SceneManager.LoadScene(0);
        }
    }

    IEnumerator LoadpreviosScene()
    {

        yield return new WaitForSeconds(90);
        SceneManager.LoadScene(0);
    }
}
