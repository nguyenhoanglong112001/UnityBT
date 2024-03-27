using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collider_detection : MonoBehaviour
{
    // Start is called before the first frame update
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Hero"))
        {
            collision.GetComponent<Knightcontroller>().Die();

            Destroy(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
}
