using UnityEngine;
using UnityEngine.SceneManagement;
public class intro : MonoBehaviour
{
   private void Update() 
   {
    if (Time.time > 5f)
    {
        SceneManager.LoadScene(1);
    } 
   }
}
