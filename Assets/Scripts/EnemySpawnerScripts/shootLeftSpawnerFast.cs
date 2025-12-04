using System.Collections;
using UnityEngine;

public class shootLeftSpawnerFast : MonoBehaviour
{ //make one for the right side too?

    //code from this video: https://youtu.be/SELTWo1XZ0c?si=dHn0AcCkka6f1ebh

    [SerializeField] private GameObject enemycarprefab;

    [SerializeField] private float enemyEndBound = 3.5f;

    [SerializeField] public randomNumberGenerator rand;

    public float RBounds = 8f;

    public float UpDownBound = -60f; //from the bottom



    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        StartCoroutine(spawnEnemy(Random.Range(enemyEndBound - 1.0f, enemyEndBound+1.0f), enemycarprefab));
    }


    private IEnumerator spawnEnemy (float interval, GameObject enemy)
    {
        yield return new WaitForSeconds(interval);
        GameObject newEnemy = Instantiate(enemy, new Vector3(Random.Range(0f, RBounds), 1.5f, UpDownBound), Quaternion.identity);
        StartCoroutine(spawnEnemy(rand.GetRandomNumber(enemyEndBound), enemy));
    }


}
