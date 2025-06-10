using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;


public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D rb;
    private Vector2 moveInput;
    private Vector2 SmoothMoveInput;
    private Vector2 SmoothMoveVelocity;
    private Camera mainCamera;
    private Animator ani;
    public float moveSpeed = 5f;
    public float RotationSpeed;
    [SerializeField]
    private float ScreeBorder;
    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        mainCamera = Camera.main;
        ani = GetComponent<Animator>();
    }

    private void SetAnimation()
    {
        bool isMoving = moveInput != Vector2.zero;
        ani.SetBool("IsMoving", isMoving);
    }
    private void FixedUpdate()
    {
        movement();
        RotationInDirectionOfInput();
        SetAnimation();
    }

    private void movement()
    {
        SmoothMoveInput = Vector2.SmoothDamp(SmoothMoveInput, moveInput, ref SmoothMoveVelocity, 0.1f);
        rb.velocity = SmoothMoveInput * moveSpeed;
        PrevatingPlayerGoingOffScreen();
    }

    private void RotationInDirectionOfInput()
    {
        if (moveInput != Vector2.zero)
        {
            Quaternion targetRotation = Quaternion.LookRotation(transform.forward, SmoothMoveInput);
            Quaternion rotation = Quaternion.RotateTowards(transform.rotation, targetRotation, RotationSpeed * Time.deltaTime);
            rb.MoveRotation(rotation);
        }
    }
    private void OnMove(InputValue value)
    {
        moveInput = value.Get<Vector2>();

    }
    private void PrevatingPlayerGoingOffScreen()
    {
        Vector2 screenPosition = mainCamera.WorldToScreenPoint(transform.position);
        if ((screenPosition.x < ScreeBorder && rb.velocity.x < 0) || (screenPosition.x > mainCamera.pixelWidth - ScreeBorder && rb.velocity.x > 0))
        {
            rb.velocity = new Vector2(0, rb.velocity.y);

        }
         if ((screenPosition.y < ScreeBorder && rb.velocity.y < 0) || (screenPosition.y > mainCamera.pixelHeight - ScreeBorder && rb.velocity.y >0))
        {
            rb.velocity = new Vector2(rb.velocity.x,0);
            
        }
    }
}
