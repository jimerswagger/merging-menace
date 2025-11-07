using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class slowSpawner : MonoBehaviour
{

    [SerializeField] private GameObject enemycarprefab;

    [SerializeField] private float enemyinterval = 3.5f;



    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        StartCoroutine(spawnEnemy(enemyinterval, enemycarprefab));
    }


    private IEnumerator spawnEnemy (float interval, GameObject enemy)
    {
        yield return new WaitForSeconds(interval);
        GameObject newEnemy = Instantiate(enemy, new Vector3(Random.Range(-6f, 6f), 1.5f, 60f), Quaternion.identity);
        StartCoroutine(spawnEnemy(interval, enemy));
    }


}
