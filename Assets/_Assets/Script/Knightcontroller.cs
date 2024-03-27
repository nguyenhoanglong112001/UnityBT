using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class Knightcontroller : MonoBehaviour
{
    // Start is called before the first frame update
    private Animator animator;
    private SpriteRenderer spriterender;
    private Rigidbody2D rigi2d;
    [SerializeField] private Collider2D attackcolliderX;
    [SerializeField] private Collider2D attackcolliderflip;
    [SerializeField] private float speed = 3.0f;
    [SerializeField] private float jumpforce;
    private bool IsGround = false;
    [SerializeField] private Collider2D crouchcollider;
    [SerializeField] private Collider2D standcollider;
    public void Start()
    {
        animator = GetComponent<Animator>();
        spriterender = GetComponent<SpriteRenderer>();
        rigi2d = GetComponent<Rigidbody2D>();
    }

    public void Update()
    {
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            transform.Translate(Vector2.left * speed * Time.deltaTime);
            animator.SetTrigger("Walk");
            spriterender.flipX = true;

        }
        else if (Input.GetKey(KeyCode.RightArrow))
        {
            transform.Translate(Vector2.right * speed * Time.deltaTime);
            animator.SetTrigger("Walk");
            spriterender.flipX = false;
        }
        else if (Input.GetKeyDown(KeyCode.J))
        {
            //animator.ResetTrigger("Idle");
            animator.SetTrigger("Attack");
            if (spriterender.flipX == true)
            {
                attackcolliderX.enabled = true;
            }
            else if (spriterender.flipX == false)
            {
                attackcolliderflip.enabled = true;
            }
        }
        else if (Input.GetKeyDown(KeyCode.UpArrow) && IsGround)
        {
            rigi2d.velocity = Vector2.up * jumpforce;
            animator.SetTrigger("Jump");
        }
        else if (Input.GetKey(KeyCode.RightControl) && IsGround)
        {
            animator.SetTrigger("Crouch");
            crouchcollider.enabled = true;
            standcollider.enabled = false;
        }
        else
        {
            animator.SetTrigger("Idle");
            attackcolliderX.enabled = false;
            attackcolliderflip.enabled = false;
            crouchcollider.enabled = false;
            standcollider.enabled = true;
        }
    }
    public void Die()
    {
        animator.SetTrigger("Die");
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Dragon"))
        {
            DragonController dragon = collision.GetComponent<DragonController>();
            dragon.LossHP();
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            IsGround = true;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            IsGround = false;
        }
    }
}
