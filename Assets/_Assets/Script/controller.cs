using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class controller : MonoBehaviour
{
    [SerializeField] private float speed =3.0f;
    [SerializeField] private float jumpforce;
    [SerializeField] private Rigidbody2D rig2d;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 posititon = transform.position;
        if (Input.GetKey(KeyCode.A))
        {
            transform.Translate(Vector2.left * speed*Time.deltaTime);
        }
        else if (Input.GetKey(KeyCode.D))
        {
            transform.Translate(Vector2.right * speed * Time.deltaTime);
        }
        else if (Input.GetKey(KeyCode.W))
        {
            rig2d.velocity = Vector2.up * jumpforce;
        }
    }
}
