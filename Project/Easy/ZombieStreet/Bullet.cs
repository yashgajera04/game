using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private Camera mainCamera;
    [SerializeField]
    private float Damnge;

    private void Awake()
    {
        mainCamera = Camera.main;
    }
    private void Update() {
        DestroyBulletOffScreen();
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.GetComponent<Enemey>())
        {
            HealthControler hc = other.GetComponent<HealthControler>();
            hc.TakeDameage(Damnge);
            Destroy(gameObject);
        }
    }
    
    private void DestroyBulletOffScreen()
    {
        Vector2 screenPosition = mainCamera.WorldToScreenPoint(transform.position);
        if (screenPosition.x < 0 || screenPosition.x > mainCamera.pixelWidth || screenPosition.y < 0 || screenPosition.y > mainCamera.pixelHeight)
        {
            Destroy(gameObject);
        }
    }

}
