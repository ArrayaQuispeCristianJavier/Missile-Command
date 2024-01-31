using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Home : MonoBehaviour
{
    public GameObject[] arrayHome;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("City"))
        {
            for(int i = 0; i < arrayHome.Length; i++)
            {
                if (arrayHome[i] != null)
                {
                    Destroy(arrayHome[i]);
                }
            }
        }
    }
}
