using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Home : MonoBehaviour
{
   public GameObject[] arrayHome;
   
   private void OnCollisionEnter2D(Collision2D other) {
    if (other.gameObject.CompareTag("Enemies"))
    {
        int randomIndex = Random.Range(0, arrayHome.Length);
        if (arrayHome[randomIndex] != null)
        {
            Destroy(arrayHome[randomIndex]);
        }
    }
   }
}
