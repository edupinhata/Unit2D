using System;
using UnityEngine;

public class Shredder : MonoBehaviour
{

    void OnTriggerEnter2D(Collider2D collision)
    {
        Destroy(collision.gameObject);
    }
}