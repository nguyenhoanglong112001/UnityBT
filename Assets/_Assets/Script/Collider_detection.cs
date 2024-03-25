using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collider_detection : MonoBehaviour
{
    // Start is called before the first frame update
    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("Destroy enemy!!");
        if (collision.gameObject.CompareTag("Hero"))
        {
            collision.gameObject.GetComponent<Knight>().Die();

            Destroy(gameObject);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Hero"))
        {
            collision.GetComponent<Knight>().Die();

            Destroy(gameObject);
        }
    }
}
