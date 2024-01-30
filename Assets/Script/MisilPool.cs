using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MisilPool : MonoBehaviour
{
    [SerializeField] GameObject misilPrefab;
    [SerializeField] int poolSize = 10;
    [SerializeField] List<GameObject> misilList;

    private static MisilPool instance;
    public static MisilPool Instance { get { return instance; } }

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }
    void Start()
    {
        AddMisilPool(poolSize);
    }
    private void AddMisilPool(int amount)
    {
        for (int i = 0; i < poolSize; i++)
        {
            GameObject misil = Instantiate(misilPrefab);
            misil.SetActive(false);
            misilList.Add(misil);
            misil.transform.parent = transform;
        }
    }
    public GameObject RequestMisil()
    {
        for (int i = 0; i < misilList.Count; i++)
        {
            if (!misilList[i].activeSelf)
            {
                misilList[i].SetActive(true);
                return misilList[i];
            }
        }
        return null;
    }
}
