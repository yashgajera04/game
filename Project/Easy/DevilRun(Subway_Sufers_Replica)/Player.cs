using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    private float originalSpeed= 30.0f;
   private float speed=30.0f;
   private float speedLastTick;
   private float speedIncreaseTime = 2.5f;
   private float speedIncreaseAmount = 0.1f;
   private float jumpForce = 25.0f;
   private float gravity=15.0f;
   private float verticalVelocity;
   private CharacterController controller;
   public int desiredLane = 1; // 0 = left, 1 = middle, 2 = right
   private  const float Lan_Distance = 50.0f; // distance between lanes
  //private const float Turn_speed = 10.0f; // speed of rotation
  public bool isStratedRunning = false;
  // Animation
  private Animator animator;
  public GameObject finish;
  public GameObject gameover;
  public GameObject enemey;

   private void Start()
    {
        controller = GetComponent<CharacterController>();
        animator = GetComponent<Animator>();
    }

   private void Update() 
   {
    if (Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
        }
        if (!isStratedRunning)
        {
            // Debug.Log(isStratedRunning);
            return;
        }

        if(Time.time - speedLastTick > speedIncreaseTime)
        {
            speedLastTick = Time.time;
            speed += speedIncreaseAmount;
            GameManger.instance.UpdatemodifiersScore(speed - originalSpeed);
        }
        if(Input.GetKeyDown(KeyCode.LeftArrow))
        {
            MoveLane(false);
        } 
        if(Input.GetKeyDown(KeyCode.RightArrow))
        {
            MoveLane(true);
        } 
        // calulate the future position of the player
        Vector3 targetPosition = transform.position.z * Vector3.forward;
        if(desiredLane == 0)
        {
            targetPosition += Vector3.left * Lan_Distance;
        } 
        else if(desiredLane == 2)
        {
            targetPosition += Vector3.right * Lan_Distance;
        }
        // else
        // {
        //     targetPosition = Vector3.zero;
        // }
        // move the player to the target position
        Vector3 moveVector = Vector3.zero;
        moveVector.x = (targetPosition.x - transform.position.x) * speed;
        // jump and gravity
        bool isGrounded = IsGrounded();
        animator.SetBool("Grounded", isGrounded);
        if(IsGrounded())
        {
//            Debug.Log("running on ground");
            verticalVelocity = -0.1f;
            if(Input.GetKeyDown(KeyCode.Space))
            {
                animator.SetTrigger("Jump");
                verticalVelocity = jumpForce;
            }
        }
        else
        {
            animator.SetBool("Grounded", true);
            verticalVelocity -= (gravity * Time.deltaTime);
            if(Input.GetKeyDown(KeyCode.Space))
            {
                verticalVelocity = -jumpForce;
                animator.SetBool("Grounded", true);
            }
        }
        moveVector.y = verticalVelocity;
        moveVector.z = speed;
        if (Input.GetKeyDown(KeyCode.Y))
        {
            moveVector.y = 50;
            moveVector.z = 69700;
             
        }
        // // 
        // Debug.Log("moveVector: " + moveVector);
        // //Debug.Log("transform.position: " + transform.position);
        // Debug.Log("targetPosition: " + targetPosition);
        // Debug.Log("desiredLane: " + desiredLane);
       // Debug.Log("verticalVelocity: " + verticalVelocity);
        // move player
        controller.Move(moveVector * Time.deltaTime);
   }

   private void MoveLane(bool goingright)
   {
        desiredLane += (goingright) ? 1 : -1;
        desiredLane = Mathf.Clamp(desiredLane, 0, 2); // 0 = left, 1 = middle, 2 = right
   }

   private bool IsGrounded()
   {
        Ray groundRay = new Ray(new Vector3(controller.bounds.center.x,(controller.bounds.center.y - controller.bounds.extents.y)+0.2f, controller.bounds.center.z), Vector3.down);
        Debug.DrawRay(groundRay.origin, groundRay.direction, Color.red,0.1f);

        return Physics.Raycast(groundRay, 0.2f + 0.1f); // check if the ray hits the ground within 0.1f distance
   }
    public void StartGame()
    {
          isStratedRunning = true;
          animator.SetBool("StartRunning", true);
    }
    private void death()
    {
        animator.SetTrigger("death");
        isStratedRunning = false;
        GameManger.instance.stopscore();
    }
    private void OnControllerColliderHit(ControllerColliderHit hit) 
    {
        switch(hit.gameObject.tag)
        {
            case "Obs":
                death();
                gameover.SetActive(true);
                break;
            case "Coin":
                GameManger.instance.coinscoreUpdate();
                Destroy(hit.gameObject);
                break;
            case "Finish":
                 Destroy(hit.gameObject);
                 Destroy(enemey);
                  isStratedRunning = false;
                 animator.SetBool("win", true);
                 finish.SetActive(true);
                 break;
            default:
                break;
        }
    }
}