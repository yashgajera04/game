using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class intro : MonoBehaviour
{
    public GameObject introUI;
    public GameObject mainUI;

    // Update is called once per frame
    void Update()
    {
        if (Time.time > 5)
        {
            introUI.SetActive(false);
            mainUI.SetActive(true);
            if (Time.time > 5)
            {
                SceneManager.LoadScene(1);
            }
        }
    }
}
