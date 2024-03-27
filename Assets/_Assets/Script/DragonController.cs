using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class DragonController : MonoBehaviour
{
    // Start is called before the first frame update
    private Animator animator;
    private SpriteRenderer spriterender;
    [SerializeField] private Collider2D crouchcollider;
    [SerializeField] private Collider2D standcollider;
    [SerializeField]private Rigidbody2D rigi2d;
    [SerializeField] private float speed = 3.0f;
    [SerializeField] private float jumpforce;
    [SerializeField] private GameObject enable;
    private bool IsGround = false;
    [SerializeField] private int HP = 5;
    private int currentHP;
    void Start()
    {
        currentHP = HP;
        animator = GetComponent<Animator>();
        spriterender = GetComponent<SpriteRenderer>();
    }
    void Update()
    {
        if (Input.GetKey(KeyCode.A))
        {
            transform.Translate(Vector2.left * speed * Time.deltaTime);
            animator.SetTrigger("Walk");
            spriterender.flipX = true;

        }
        else if (Input.GetKey(KeyCode.D))
        {
            transform.Translate(Vector2.right * speed * Time.deltaTime);
            animator.SetTrigger("Walk");
            spriterender.flipX = false;
        }
        else if (Input.GetKeyDown(KeyCode.W) && IsGround)
        {
            rigi2d.velocity = Vector2.up * jumpforce;
            animator.SetTrigger("Jump");
        }
        else if (Input.GetKey(KeyCode.Space))
        {
            animator.SetTrigger("Attack");
            if (enable.activeInHierarchy == false)
            {
                enable.SetActive(true);
            }
        }
        else if (Input.GetKey(KeyCode.LeftControl) && IsGround)
        {
            animator.SetTrigger("Crouch");
            crouchcollider.enabled = true;
            standcollider.enabled = false;
        }
        else
        {
            animator.SetTrigger("Idle");
            crouchcollider.enabled = false;
            standcollider.enabled = true;
        }
    }
    public void Die()
    {
        animator.SetTrigger("Die");
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

    public void LossHP()
    {
        currentHP -= 1;
        Debug.Log($"{currentHP}/5");
        if ( currentHP == 0)
        {
            Die();
        }
    }
}
