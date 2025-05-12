using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class brickes : MonoBehaviour
{
  public int health{get; private set;}
  public SpriteRenderer sr {get; private set;}
  public Sprite[] state;
  public bool unbreakable;
  public int Points=100;
  private void Awake() 
  {
    this.sr = GetComponent<SpriteRenderer>();
  }
  private void Start() 
  {
   Resetbrick();  
  }
  private void hit()
  {
    if(this.unbreakable)
    {
        return;
    }
    this.health--;
    if(this.health <=0)
    {
        this.gameObject.SetActive(false);
    }
    else
    {
        this.sr.sprite = this.state[this.health-1];
    }
    FindObjectOfType<GameManager>().Hit(this);
    //this.gm.GetComponent<GameManager>().Hit(this);

  }
  private void OnCollisionEnter2D(Collision2D collision) 
  {
    if(collision.gameObject.name == "ball")
    {
        this.hit();
    }
  }

  public void Resetbrick()
  {
    this.gameObject.SetActive(true);
    if(!this.unbreakable)
    {
        this.health = this.state.Length;
        this.sr.sprite = this.state[this.health-1];
    }
  }
}
