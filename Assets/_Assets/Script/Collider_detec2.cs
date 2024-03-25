using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collider_detec2 : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Dragon"))
        {
            collision.gameObject.GetComponent<Dragon>().Die();

            Destroy(gameObject);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Dragon"))
        {
            collision.GetComponent<Dragon>().Die();

            Destroy(gameObject);
        }
    }
}
