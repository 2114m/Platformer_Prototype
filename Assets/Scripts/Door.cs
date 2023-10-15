using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    public SpriteRenderer render;
    public Sprite openDoor;
    public BoxCollider2D doorColider;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "player")
        {
            PlayerEq eq = collision.gameObject.GetComponent<PlayerEq>();
            if (eq.keys >= 1)
            {
                eq.keys -= 1;

                render.sprite = openDoor;

                doorColider.enabled = false;
            }
        }
    }
}
