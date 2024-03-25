using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Knight : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] public GameObject enable;
    public void Die()
    {
        gameObject.SetActive(false);
        Trigger();
        gameObject.SetActive(false);
        Trigger();
    }

    public void Trigger()
    {
        if (enable.activeInHierarchy == false)
        {
            enable.SetActive(true);
        }
    }
}
