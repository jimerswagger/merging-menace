using UnityEngine;
using System.Collections;

public class missileSpawner : MonoBehaviour
{
    [SerializeField] private GameObject dangerHover;
    [SerializeField] private GameObject dangerAttack;

    [SerializeField] private float missileInterval = 3.5f;

    private float timerForHover = 0f;

    private float hoverDuration = 2f;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        StartCoroutine(spawnMissile(Random.Range(2.0f, missileInterval+1.0f), dangerHover, dangerAttack));
    }

    void Update()
    {
        //StartCoroutine(spawnMissile(Random.Range(2.0f, missileInterval+1.0f), dangerHover, dangerAttack));

        timerForHover += Time.deltaTime;
    }

    private IEnumerator spawnMissile (float interval, GameObject hover, GameObject attack)
    {
        yield return new WaitForSeconds(interval);
        GameObject newDangerHover = Instantiate(hover, new Vector3(Random.Range(0f, 8f), 1f, Random.Range(-10f, 50f)), Quaternion.Euler(90,0,0));

        yield return new WaitForSeconds(3f);

        GameObject newDangerAttack = Instantiate(attack, newDangerHover.transform.position, Quaternion.Euler(90,0,0));
        Destroy(newDangerHover);
        //Missile come in and destroy at newDangerAttack position
        Destroy(newDangerAttack, 1f);
            

        StartCoroutine(spawnMissile(interval, hover, attack));
    }
}
