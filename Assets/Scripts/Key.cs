using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Key : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "player")
        {
            Destroy(gameObject);

            PlayerEq eq = collision.gameObject.GetComponent<PlayerEq>();
            eq.keys += 1;
        }
    }
}