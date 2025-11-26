using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shootLeftSpawnerFast : MonoBehaviour
{

    //code from this video: https://youtu.be/SELTWo1XZ0c?si=dHn0AcCkka6f1ebh

    [SerializeField] private GameObject enemycarprefab;

    [SerializeField] private float enemyinterval = 3.5f;



    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        StartCoroutine(spawnEnemy(Random.Range(enemyinterval - 1.0f, enemyinterval+1.0f), enemycarprefab));
    }


    private IEnumerator spawnEnemy (float interval, GameObject enemy)
    {
        yield return new WaitForSeconds(interval);
        GameObject newEnemy = Instantiate(enemy, new Vector3(Random.Range(0f, 8f), 1.5f, -60f), Quaternion.identity);
        StartCoroutine(spawnEnemy(interval, enemy)); //if player can move camera then change '60f' to be player.transform.z + 60f.
    }


}
