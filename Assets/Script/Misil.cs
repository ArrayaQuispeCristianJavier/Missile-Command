using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Misil : MonoBehaviour
{
    [SerializeField] float misilSpeed = 30f;
    private Rigidbody2D misilRb;
    private float destroyDelay = 7f;

    private void Awake()
    {
        misilRb = GetComponent<Rigidbody2D>();
    }
    private void OnEnable()
    {
         misilRb.velocity = Vector2.up * misilSpeed;
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        //Destroy(gameObject);
        gameObject.SetActive(false);
    }
    public void LaunchProjectile(Vector2 direction)
    {
        misilRb.velocity = direction * misilSpeed;
        Destroy(gameObject, destroyDelay);
    }
}
