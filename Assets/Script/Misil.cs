using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Misil : MonoBehaviour
{
    [SerializeField] float misilSpeed = 30f;
    private Rigidbody2D misilRb;
    private float destroyDelay = 7f;
    GameObject gameManagerObj;
    GameManager gameManager;

    private void Awake()
    {
        misilRb = GetComponent<Rigidbody2D>();
    }
    private void OnEnable()
    {
         misilRb.velocity = Vector2.up * misilSpeed;
    }
    private void Start()
    {
        gameManagerObj = GameObject.Find("Game Manager");
        if (gameManagerObj == null)
        {
            Debug.Log("Objeto no encontrado");
        }
        else
        {
            gameManager = gameManagerObj.GetComponent<GameManager>();
            gameManager.enemyEliminated--;
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (gameManager != null)
        {
            gameManager.enemyEliminated--;
        }
        Destroy(gameObject);
    }
    public void LaunchProjectile(Vector2 direction)
    {
        misilRb.velocity = direction * misilSpeed;
        Destroy(gameObject, destroyDelay);
    }
}
