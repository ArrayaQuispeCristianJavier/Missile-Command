using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;

public class MovementSpawner : MonoBehaviour
{
    [SerializeField] Enemy enemyPrefab;
    private float randomPositionX;
    private float timeRandomRespawnEnemy;

    private ObjectPool<Enemy> enemyPool;
    private void Start() {
        randomPositionX = Random.Range(-19.92f, 20.06f);
        
        enemyPool = new ObjectPool<Enemy>(()=>{
            Enemy enemy = Instantiate(enemyPrefab, new Vector2(randomPositionX, 13.7f), Quaternion.identity);
            enemy.DesactivateActionEnemy(DesactivateEnemyPool);
            if (timeRandomRespawnEnemy == 2f)
            {
                enemy.ChangeColor(Color.blue);
                Debug.Log("Misil Jefe");
            }
            return enemy;
        }, enemy =>{
            enemy.transform.position = new Vector2(randomPositionX, 13.7f);
            enemy.gameObject.SetActive(true);
        }, enemy =>{
            enemy.gameObject.SetActive(false);
        }, enemy =>{
            Destroy(enemy.gameObject);
        }, true, 5,6);
        StartCoroutine(GeneratorEnemy());
    }
    private void Update() {
       randomPositionX = Random.Range(-19.92f, 20.06f);
       timeRandomRespawnEnemy = Random.Range(1f, 3f);
    }
    private void EnemySpawn(){
        enemyPool.Get();
    }
    private void DesactivateEnemyPool(Enemy enemy){
        enemy.ResetColor();
        enemyPool.Release(enemy);
    }
    IEnumerator GeneratorEnemy(){
        while (true)
        {
            EnemySpawn();
            yield return new WaitForSeconds(timeRandomRespawnEnemy);
        }
    }
}
