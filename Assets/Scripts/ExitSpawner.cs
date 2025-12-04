using UnityEngine;
using System.Collections;

public class ExitSpawner : MonoBehaviour
{
    //code from this video: https://youtu.be/SELTWo1XZ0c?si=dHn0AcCkka6f1ebh

    [SerializeField] private GameObject exitPrefab;

    [SerializeField] public randomNumberGenerator rand;

    public float ToSpawn = 11f;

    public float exitInterval = 30f;

    public float UpDownBound = 60f; //from the top



    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        StartCoroutine(spawnEnemy(exitInterval, exitPrefab));
    }


    private IEnumerator spawnEnemy (float interval, GameObject enemy)
    {
        yield return new WaitForSeconds(interval);
        GameObject newEnemy = Instantiate(enemy, new Vector3(ToSpawn, 0.5f, UpDownBound), Quaternion.identity);
        StartCoroutine(spawnEnemy(Random.Range(exitInterval - 5f, exitInterval), enemy));
    }
}
