using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;

public class Shoot : MonoBehaviour
{
    [SerializeField] Misil misilPrefab;
    [SerializeField] float timeShoot;
    [SerializeField] Transform controlShoot;
    private float timeNextShoot = 0;
    private ObjectPool<Misil> misilPool;

    private void Start() {
        misilPool = new ObjectPool<Misil>(() => {
            Misil misil = Instantiate(misilPrefab, controlShoot.position, controlShoot.rotation);
            misil.DesactivateActionMisil(DesactivateMisil);
            return misil;
        }, misil =>{
            misil.gameObject.SetActive(true);
            misil.transform.position = controlShoot.position;
        }, misil =>{
            misil.gameObject.SetActive(false);
        },misil =>{
            Destroy(misil.gameObject);
        },true,3,3);
    }

    void Update()
    {
        if (timeNextShoot > 0)
        {
            timeNextShoot -= Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.Space))
        {
            if (timeNextShoot <= 0)
            {
                FunctionShoot();
                timeNextShoot = timeShoot;
            }
        }
    }
    /*private void ActiveMisil(Misil misil){
        misil.gameObject.SetActive(true);
    }*/
    private void FunctionShoot()
    {
        misilPool.Get();
    }
    private void DesactivateMisil(Misil misil){
        misilPool.Release(misil);
    }
}
