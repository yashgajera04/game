using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemey : MonoBehaviour
{
    [SerializeField]
    private float moveSpeed;

    [SerializeField]
    private float rotationSpeed;
    [SerializeField]
    private float ObstacleCircleRadius;

    [SerializeField]
    private float ObstacleDistance;

    [SerializeField]
    private LayerMask ObstacleLayerMask;

    private Rigidbody2D rb;
    private PlayerAwaernes playerAwaernes;
    private Vector2 TragetDirection;
    private float ChnageDirctionCooldaown;
    private Camera mainCamera;
    [SerializeField]
    private float ScreeBorder;
    private RaycastHit2D[] ObstacleCollisions;
    private float ObstacleCoolDown;
    private Vector2 ObstacleAvoidanceDirection;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        playerAwaernes = GetComponent<PlayerAwaernes>();
        TragetDirection = transform.up;
        mainCamera = Camera.main;
        ObstacleCollisions = new RaycastHit2D[10];
    }
    private void FixedUpdate()
    {
        UpdateTargetPosition();
        RotateTowardsTarget();
        SetVelocity();
    }

    private void UpdateTargetPosition()
    {
        HandleRandomDirectionChange();
        ObstacleHandle();
        HandlePlayuerTargeting();
        HandleEnemeyOffScreen();
    }
    private void HandleRandomDirectionChange()
    {
        ChnageDirctionCooldaown -= Time.deltaTime;
        if (ChnageDirctionCooldaown <= 0)
        {
            float randomAngle = Random.Range(-90f, 90f);
            Quaternion rotation = Quaternion.AngleAxis(randomAngle, transform.forward);
            TragetDirection = rotation * transform.up;
            ChnageDirctionCooldaown = Random.Range(1f, 5f); // Random cooldown between 1 and 3 seconds
        }
    }
    private void HandlePlayuerTargeting()
    {
        if (playerAwaernes.AwareOfPlayer)
        {
            TragetDirection = playerAwaernes.DirectionToPlayer;
        }
    }
    private void HandleEnemeyOffScreen()
    {
         Vector2 screenPosition = mainCamera.WorldToScreenPoint(transform.position);
        if ((screenPosition.x < ScreeBorder && TragetDirection.x < 0) || (screenPosition.x > mainCamera.pixelWidth - ScreeBorder && TragetDirection.x > 0))
        {
            rb.velocity = new Vector2(-TragetDirection.x,TragetDirection.y);

        }
         if ((screenPosition.y < ScreeBorder && TragetDirection.y < 0) || (screenPosition.y > mainCamera.pixelHeight - ScreeBorder && TragetDirection.y >0))
        {
            rb.velocity = new Vector2(TragetDirection.x,-TragetDirection.y);
            
        }
    }
    private void ObstacleHandle()
    {
        ObstacleCoolDown -= Time.deltaTime;
        var ConatactFilter = new ContactFilter2D();
        ConatactFilter.SetLayerMask(ObstacleLayerMask);
        int NumberOfCollison = Physics2D.CircleCast(transform.position, ObstacleCircleRadius, transform.up, ConatactFilter, ObstacleCollisions, ObstacleDistance);
        for (int i = 0; i < NumberOfCollison; i++)
        {
            var hit = ObstacleCollisions[i];
            if (hit.collider.gameObject == gameObject)
            {
                continue;
            }
            if (ObstacleCoolDown <= 0)
            {
                ObstacleAvoidanceDirection = hit.normal;
                ObstacleCoolDown = 0.5f;
            }
            var targetRotation = Quaternion.LookRotation(transform.forward, ObstacleAvoidanceDirection);
            var rotation = Quaternion.RotateTowards(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);
            TragetDirection = rotation * Vector2.up;
            break;
        }
    }
    private void RotateTowardsTarget()
    {
        Quaternion targetRotation = Quaternion.LookRotation(transform.forward, TragetDirection);
        Quaternion rotation = Quaternion.RotateTowards(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);
        rb.SetRotation(rotation);
    }
    private void SetVelocity()
    {
            rb.velocity = transform.up * moveSpeed;
    }
}
