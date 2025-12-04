using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class slowSpawner : MonoBehaviour
{

    //code from this video: https://youtu.be/SELTWo1XZ0c?si=dHn0AcCkka6f1ebh

    [SerializeField] private GameObject enemycarprefab;

    [SerializeField] private float enemyEndBound = 3.5f;

    [SerializeField] public randomNumberGenerator rand;

    public float LRBounds = 8f;

    public float UpDownBound = 60f; //from the top



    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        StartCoroutine(spawnEnemy(Random.Range(1.0f, enemyEndBound+1.0f), enemycarprefab));
    }


    private IEnumerator spawnEnemy (float interval, GameObject enemy)
    {
        yield return new WaitForSeconds(interval);
        GameObject newEnemy = Instantiate(enemy, new Vector3(Random.Range(-1*LRBounds, LRBounds), 1.5f, UpDownBound), Quaternion.identity);
        StartCoroutine(spawnEnemy(rand.GetRandomNumber(enemyEndBound), enemy));
    }


}
