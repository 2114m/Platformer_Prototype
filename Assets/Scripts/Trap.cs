using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trap : MonoBehaviour
{
    public int damage = 1;
    public float bounceForce = 10f;
    public bool destroyOnCollision = false;
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "player")
        {
           PlayerEq eq = collision.gameObject.GetComponent<PlayerEq>();
            eq.hearts -= 1;

            var rigid = collision.gameObject.GetComponent<Rigidbody2D>();
            rigid.AddForce(new Vector2(0, bounceForce));

            if(eq.hearts <= 0)
            {
                Destroy(collision.gameObject);
            }

            if (destroyOnCollision)
            {
                Destroy(gameObject);
            }
        }
    }
}
