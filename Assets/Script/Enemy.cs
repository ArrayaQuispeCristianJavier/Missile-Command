using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] float velocityEnemy = 0.9f;
    private Rigidbody2D rb;
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    private void FixedUpdate()
    {
        if (rb.velocity.y < 0)
        {
            rb.velocity = new Vector2(rb.velocity.x, rb.velocity.y * velocityEnemy);
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        //Verificamos si el objeto con el que colisiono tiene el tag City
        if (collision.gameObject.CompareTag("City"))
        {
            Destroy(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
}
