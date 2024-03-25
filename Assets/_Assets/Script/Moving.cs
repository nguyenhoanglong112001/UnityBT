using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Moving : MonoBehaviour
{
    [SerializeField] private Rigidbody2D rig2D;
    [SerializeField] private int speed;
    // Start is called before the first frame update
    void Start()
    {
        speed = Random.Range(3, 10);
    }

    // Update is called once per frame
    void Update()
    {
        rig2D.velocity = Vector2.right*speed;
    }
}
