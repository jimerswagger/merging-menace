using UnityEngine;
using System.Collections;

public class missileSpawner : MonoBehaviour
{
    [SerializeField] private GameObject dangerHover;
    [SerializeField] private GameObject dangerAttack;

    [SerializeField] private GameObject missile;

    [SerializeField] private float missileInterval = 3.5f;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        StartCoroutine(spawnMissile(Random.Range(1.0f, missileInterval+1.0f), dangerHover, dangerAttack));
    }

    private IEnumerator spawnMissile (float interval, GameObject hover, GameObject attack)
    {
        Debug.Log("Interval: " + interval);
        yield return new WaitForSeconds(interval);
        GameObject newDangerHover = Instantiate(hover, new Vector3(Random.Range(0f, 8f), 1f, Random.Range(0f, 20f)), Quaternion.Euler(90,0,0));

        yield return new WaitForSeconds(3f);

        GameObject newDangerAttack = Instantiate(attack, newDangerHover.transform.position, Quaternion.Euler(90,0,0));
        Destroy(newDangerHover);
        //Missile come in and destroy at newDangerAttack position

        GameObject redMissile = Instantiate(missile, new Vector3(newDangerAttack.transform.position.x, newDangerAttack.transform.position.y + 20f, newDangerAttack.transform.position.z), Quaternion.Euler(180,0,0));
        Destroy(newDangerAttack, 1f);
            

        StartCoroutine(spawnMissile(interval, hover, attack));
    }
}
