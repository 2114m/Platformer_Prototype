using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float jumpPower = 5f;
    public float jumpDoublePower = 5f;
    public int maxJumps = 2;
    public float dashPower = 5f;
    public float landPuffTime = 3f;
    public Rigidbody2D rigid;
    public Animator anim;
    public SpriteRenderer render;
    public ParticleSystem dashParticle;
    public ParticleSystem landParticle;
    

    private bool onGround = false;
    private int doubleJump = 0;
    private float dashAcc = 0f;
    private float lastGroundTime = 0f;
    private void FixedUpdate()
    {
        float move = Input.GetAxis("Horizontal"); //A / D
        rigid.velocity = new Vector2(move * moveSpeed * Time.fixedDeltaTime, rigid.velocity.y);

        anim.SetBool("moving", move != 0);
        render.flipX = move < 0;
        
        
        
        if (dashAcc > 0)
        {
            dashAcc -= Time.fixedDeltaTime;
            rigid.velocity += new Vector2(move * dashPower, 0);
        }
        
    }

    private void Update()
    {
        bool canJump = onGround;
        if(!onGround && doubleJump > 0)
        {
            canJump = true;
        }
        if (Input.GetKeyDown(KeyCode.Space) && canJump)
        {
            if(onGround)
                rigid.AddForce(new Vector2(0, jumpPower));
            else
                rigid.AddForce(new Vector2(0, jumpDoublePower));
            doubleJump -= 1;
        }

        float move = Input.GetAxis("Horizontal");
        if (Input.GetKeyDown(KeyCode.LeftShift) && move != 0)
        {
            //rigid.AddForce(new Vector2(dashPower * move, 0));
            dashAcc = 0.2f;
            Debug.Log("DASHHH");
            //particle.transform.localScale = new(render.flipX ? -1 : 1, 1, 1);
            if (move < 0)
            {
                dashParticle.transform.localScale = new(-1, 1, 1);
            }
            else
            {
                dashParticle.transform.localScale = new(1, 1, 1);
            }
            dashParticle.Play();
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.layer == LayerMask.NameToLayer("ground"))
        {
            onGround = true;
            anim.SetBool("fall", false);
            doubleJump = maxJumps;

            float delta = Time.time - lastGroundTime;
            if (delta > landPuffTime)
            {
                landParticle.Play();
            }
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer("ground"))
        {
            onGround = false;
            anim.SetBool("fall", true);
            lastGroundTime = Time.time;
        }
    }
}
