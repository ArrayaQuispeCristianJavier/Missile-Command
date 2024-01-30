using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanonPlayer : MonoBehaviour
{
    private Camera cam;
    private float rotationSpeed = 10f;
    [SerializeField] Misil misilPrefab;
    [SerializeField] Transform shootPosition;
    void Start()
    {
        cam = Camera.main;
    }

    
    void Update()
    {
        Vector2 mouseWorldPoint = cam.ScreenToWorldPoint(Input.mousePosition);
        Vector2 direction = mouseWorldPoint - (Vector2)transform.position;
        transform.up = Vector2.MoveTowards(transform.up, direction, rotationSpeed * Time.deltaTime);
        if (Input.GetMouseButtonDown(0))
        {
            Misil misil =Instantiate(misilPrefab, shootPosition.position, transform.rotation);
            misil.LaunchProjectile(transform.up);
        }
    }
}
