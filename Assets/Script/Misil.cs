using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Misil : MonoBehaviour
{
    [SerializeField] float speedMovement;
    [SerializeField] float timeOfLife;
    private Action<Misil> desactivateAction;
    private bool isAlive = true;
    private Rigidbody2D rb;


    private void Awake() {
        rb = GetComponent<Rigidbody2D>();
    }
    private void OnEnable() 
    {
        StartCoroutine(DesactivateTime());
        rb.velocity = transform.up * speedMovement;
    }
    private void Update() 
    {
        if (isAlive)
        {
         transform.Translate(Vector2.up * speedMovement * Time.deltaTime);
        }
    }
    private void OnCollisionEnter2D(Collision2D other) {
        if (other.gameObject.CompareTag("Enemy"))
        {
           DestroyMisil();
        }
    }
    private void OnBecameInvisible() {
        DestroyMisil();
    }
    private void DestroyMisil(){
        isAlive = false;
        if (desactivateAction != null)
        {
            desactivateAction(this);
        }
        ReturnToPool();
    }
    public void DesactivateActionMisil(Action<Misil> desactivateActionParameter)
    {
        desactivateAction = desactivateActionParameter;
    }
    private IEnumerator DesactivateTime(){
        yield return new WaitForSeconds(timeOfLife);
        if (isAlive)
        {
            DestroyMisil();
        }
    }
    private void ReturnToPool(){
        gameObject.SetActive(false);
    }
}
