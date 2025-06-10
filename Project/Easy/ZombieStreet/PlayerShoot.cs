using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerShoot : MonoBehaviour
{
    [SerializeField]
    private GameObject bulletPrefab;
    [SerializeField]
    private float bulletSpeed;
    [SerializeField]
    private Transform gunoffset;
    [SerializeField]
    private float timebetweenShots;
    private bool ContiueShooting;
    private float timeLastShot;
    private bool SingleShot;

    // Update is called once per frame
    void Update()
    {
        if (ContiueShooting || SingleShot)
        {
            float timeSinceLastShot = Time.time - timeLastShot;
            if (timeSinceLastShot >= timebetweenShots)
            {
                Shoot();
                timeLastShot = Time.time; 
                SingleShot = false;
            }
             
        }
    }
    private void Shoot()
    {
        GameObject bullet = Instantiate(bulletPrefab, gunoffset.position, transform.rotation);
        Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
        rb.velocity = transform.up * bulletSpeed;
    }

    private void OnFire(InputValue inputValue)
    {
        ContiueShooting = inputValue.isPressed;
        if(inputValue.isPressed)
        {
             SingleShot= true;
        }
    }

}
