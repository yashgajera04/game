using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class paddle : MonoBehaviour
{
    public Rigidbody2D rb {get; private set;}
    public Vector2 dir {get; private set;}
    public float speed=30f;
    public float maxangle=75f;

    private void Awake() 
    {
       this.rb=GetComponent<Rigidbody2D>();   
    }

    private void Update() 
    {
        if(Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
        {
            this.dir=Vector2.left;
        }    
        else if(Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
        {
            this.dir=Vector2.right;
        }
        else
        {
            this.dir=Vector2.zero;
        }
    }
    private void FixedUpdate() 
    {
        if(this.dir != Vector2.zero)
        {
            this.rb.AddForce(this.dir * speed);
        }    
    }
    public void Resetpaddle()
    {
        this.transform.position = new Vector2(0,this.transform.position.y);
        this.rb.velocity = Vector2.zero;
    }
    private void OnCollisionEnter2D(Collision2D collision) 
    {
        ball b = collision.gameObject.GetComponent<ball>();
        if(b != null)
        {
            Vector3 paddlepos = this.transform.position;
            Vector2 hitpos = collision.contacts[0].point;

            float offset = paddlepos.x - hitpos.x;
            float width = collision.otherCollider.bounds.size.x/2;

            float currentangle = Vector2.Angle(Vector2.up, b.rb.velocity);
            float bounceangle = (offset/width) * this.maxangle;
            float newangle = Mathf.Clamp(currentangle+bounceangle, -maxangle, maxangle);

            Quaternion rotation =  Quaternion.AngleAxis(newangle, Vector3.forward);
            b.rb.velocity = rotation * Vector2.up * b.rb.velocity.magnitude;
        }
    }
}
