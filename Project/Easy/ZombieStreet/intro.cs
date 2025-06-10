using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class intro : MonoBehaviour
{
   

    // Update is called once per frame
    void Update()
    {
        if (Time.time > 5)
        {
                SceneManager.LoadScene("Menu");
        }
    }
}
