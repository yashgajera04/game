using UnityEngine.SceneManagement;
using UnityEngine;

public class entrypoint : MonoBehaviour
{
    public void onclickplay()
    {
        SceneManager.LoadScene(2);
    }
    public void onclickmenu()
    {
       SceneManager.LoadScene(1);
    }
}
