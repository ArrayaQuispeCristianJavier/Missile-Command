using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementSpawner : MonoBehaviour
{
    [SerializeField] GameObject enemyPrefab;
    void Start()
    {
        StartCoroutine(SpawnEnemy());
    }
    private IEnumerator SpawnEnemy()
    {
        float spawnTime = Random.Range(1,3);
        while (true)
        {
            float randomX = Random.Range(-19.92f, 20.06f);
            Vector2 randomPosition = new Vector2(randomX, 13.94f);
            Instantiate(enemyPrefab, randomPosition, Quaternion.identity);
            Debug.Log("Enemigo generado");
            yield return new WaitForSeconds(spawnTime);
        }
    }
}
