using UnityEngine;

public class paddle : MonoBehaviour
{
    protected Rigidbody2D rb;
    public float speed = 10.0f;

     private void Awake() 
     {
        rb = GetComponent<Rigidbody2D>();
     }
}
