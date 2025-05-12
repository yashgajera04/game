using UnityEngine;

public class miss : MonoBehaviour
{
   private void OnCollisionEnter2D(Collision2D collision) 
  {
    if(collision.gameObject.name == "ball")
    {
         FindObjectOfType<GameManager>().LoseLife();
    }
  }
}
