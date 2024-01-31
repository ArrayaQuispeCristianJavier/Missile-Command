using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private float misilOffset = 0.50f;
   
    void FixedUpdate()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            AttackMisil();
        }
    }
    public void AttackMisil()
    {
        GameObject misil = MisilPool.Instance.RequestMisil();
        misil.transform.position = transform.position + Vector3.up * misilOffset;
    }
}
