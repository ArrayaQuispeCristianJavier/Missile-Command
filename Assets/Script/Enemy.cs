using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Enemy : MonoBehaviour
{
    [SerializeField] float velocityEnemy = 0.9f;
    private Rigidbody2D rb;

    private Action<Enemy> desactivateAction;

    private Color originalColor;

    private void OnEnable()
    {
        rb = GetComponent<Rigidbody2D>();
        originalColor = GetComponent<SpriteRenderer>().color;//Guardar el color original
        StartCoroutine(DesactivateTime());
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
        //Verificamos si el objeto con el que colisiono tiene el tag City y House
        if (collision.gameObject.CompareTag("City") || collision.gameObject.CompareTag("House"))
        {
            desactivateAction(this);
        }
    }
    public void DesactivateActionEnemy(Action<Enemy> desactivateActionParameter){
        desactivateAction = desactivateActionParameter;
    }
     IEnumerator DesactivateTime(){
        yield return new WaitForSeconds(30f);
        desactivateAction(this);
    }
    public void ChangeColor(Color newColor){
        GetComponent<SpriteRenderer>().color = newColor;
    }
    public void ResetColor(){
        GetComponent<SpriteRenderer>().color = originalColor;
    }
}