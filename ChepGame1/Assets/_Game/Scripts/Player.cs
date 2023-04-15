using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private Animator anim;
    [SerializeField] private LayerMask groundLayer;
    [SerializeField] private float speed = 5;
    [SerializeField] private float jumpForce = 350;

    private bool isGrounded = true;
    private bool isJumping = false;
    private bool isAttack = false;
    private bool isDeath = false;

    private float horizontal;

    private string currentAnimName;

    private int coin = 0;

    private Vector3 savePoint;

    // Start is called before the first frame update
    void Start()
    {
        SavePoint();

        OnInit();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        isGrounded = CheckGrounded();

        horizontal = Input.GetAxisRaw("Horizontal");

        if (isDeath)
        {
            return;
        }

        if (isAttack )
        {
            rb.velocity = Vector2.zero;
            return;
        }

        if (isGrounded)
        {
            if (isJumping)
            {
                return;
            }

            if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
            {
                Jump();
            }

            if (Mathf.Abs(horizontal) > 0.1f)
            {
                ChangeAnim("Run");
            }

            if (Input.GetKeyDown(KeyCode.C) && isGrounded)
            {
                Attack();
            }

            if (Input.GetKeyDown(KeyCode.V) && isGrounded)
            {
                Throw();
            }
        }

        if (!isGrounded && rb.velocity.y < 0)
        {
            ChangeAnim("Fall");
            isJumping = false;
        }

        if (Mathf.Abs(horizontal) > 0.1f)
        {
            rb.velocity = new Vector2(horizontal * Time.fixedDeltaTime * speed, rb.velocity.y);
            transform.rotation = Quaternion.Euler(new Vector3(0, horizontal > 0 ? 0 : 180, 0));
            //transform.localScale = new Vector3(horizontal, 1, 1);
        }
        else if (isGrounded)
        {
            ChangeAnim("Idle");
            rb.velocity = Vector2.zero;
        }
    }

    public void OnInit()
    {
        isDeath = false;
        isAttack = false;

        transform.position = savePoint;

        ChangeAnim("Idle");
    }

    private bool CheckGrounded()
    {
        Debug.DrawLine(transform.position, transform.position + Vector3.down * 1.1f, Color.red);

        RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.down, 1.1f, groundLayer);

        //if (hit.collider != null)
        //{
        //    return true;
        //}
        //else
        //{
        //    return false;
        //}

        return hit.collider != null;
    }

    private void Attack()
    {
        ChangeAnim("Attack");
        isAttack = true;
        Invoke(nameof(ResetAttack), 0.5f);
    }

    private void Throw()
    {
        ChangeAnim("Throw");
        isAttack = true;
        Invoke(nameof(ResetAttack), 0.5f);
    }

    private void ResetAttack()
    {
        isAttack = false;
        ChangeAnim("Idle");
    }

    private void Jump()
    {
        isJumping = true;
        ChangeAnim("Jump");
        rb.AddForce(jumpForce * Vector2.up);
    }

    private void ChangeAnim(string aniName)
    {
        if (currentAnimName != aniName)
        {
            anim.ResetTrigger(aniName);
            currentAnimName = aniName;
            anim.SetTrigger(currentAnimName);
        }
    }

    internal void SavePoint()
    {
        savePoint = transform.position;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Coin")
        {
            coin++;
            Destroy(collision.gameObject);
        }
        if (collision.tag == "DeathZone")
        {
            isDeath = true;
            ChangeAnim("Die");

            Invoke(nameof(OnInit), 1f);
        }
    }


}
