using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemey : MonoBehaviour
{
   public GameObject player;
    private Player player_script;
   private CharacterController controller;
    private Animator animator;
   private void Start() 
   {
        controller = GetComponent<CharacterController>();
         animator = GetComponent<Animator>(); 
   }
   private void Awake() 
   {
      player_script =GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();    
   }
   private void Update() 
   {
     if(player_script.isStratedRunning )
     {
       animator.SetBool("chase", true);
       Vector3 moveVector = Vector3.zero;
         moveVector.x = (player.transform.position.x - transform.position.x) * 10.0f;
         moveVector.z =(player.transform.position.z - transform.position.z) ;
         moveVector.y = (player.transform.position.y - transform.position.y) * 10.0f;
         controller.Move(moveVector * Time.deltaTime);
     }
     if(player_script.isStratedRunning == false)
     {
//        Debug.Log("Player is dead");
         animator.SetBool("chase", false);
     }
    
   }
}
