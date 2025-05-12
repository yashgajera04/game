using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class ball : MonoBehaviour
{
    public Rigidbody2D rb {get; private set;}
    public float speed=500f;

     private void Awake() 
    {
       this.rb=GetComponent<Rigidbody2D>();   
    }

    private void Start() 
    {
        Resetball();
    }
    public void Resetball()
    {
        this.transform.position = Vector2.zero;
        this.rb.velocity = Vector2.zero;
        Invoke(nameof(RandomThrow),1f);
    }
   void RandomThrow()
   {
        Vector2 Force = Vector2.zero;
        Force.x = Random.Range(-1f,1f);
        Force.y = -1f;
        rb.AddForce(Force * this.speed);
   }
   private void OnCollisionEnter2D(Collision2D other) 
   {
        rb.AddForce(rb.velocity.normalized * 20f);
   }
}
