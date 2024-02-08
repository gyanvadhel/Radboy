using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneToBeLoad : MonoBehaviour
{
   [SerializeField] float delayBeforeLoading = 0.8f;
    private float timeElapsed;

    void Update()
    {
        timeElapsed += Time.deltaTime;

        if(timeElapsed > delayBeforeLoading)
        {
            SceneManager.LoadScene("Level 1");
        }
    }
}
