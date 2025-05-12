using UnityEngine;

public class bouncy : MonoBehaviour
{
    public float bouncystr;

    private void OnCollisionEnter2D(Collision2D collision) 
    {
        ballmove ball = collision.gameObject.GetComponent<ballmove>();
        if (ball != null)
        {
            Vector2 normal = collision.GetContact(0).normal;
            ball.AddForce(-normal * this.bouncystr);
        }
    }
}
