using UnityEngine;
using System.Collections;

public class missileSpawner : MonoBehaviour
{
    [SerializeField] private GameObject dangerHover;
    [SerializeField] private GameObject dangerAttack;

    [SerializeField] private GameObject missile;

    [SerializeField] private float missileEndBound = 5f;

    public float LRBounds = 8f;

    [SerializeField] public randomNumberGenerator rand;


    void Start()
    {
        StartCoroutine(spawnMissile(Random.Range(1.0f, missileEndBound+1.0f), dangerHover, dangerAttack));
    }

    private IEnumerator spawnMissile (float interval, GameObject hover, GameObject attack)
    {
        //Debug.Log("Interval: " + interval);
        yield return new WaitForSeconds(interval);
        GameObject newDangerHover = Instantiate(hover, new Vector3(Random.Range(-1*LRBounds, LRBounds), 1f, Random.Range(0f, 20f)), Quaternion.Euler(90,0,0));

        yield return new WaitForSeconds(3f);

        GameObject newDangerAttack = Instantiate(attack, newDangerHover.transform.position, Quaternion.Euler(90,0,0));
        Destroy(newDangerHover);
        
        //Missile come in and destroy at newDangerAttack position
        GameObject redMissile = Instantiate(missile, new Vector3(newDangerAttack.transform.position.x, newDangerAttack.transform.position.y + 22f, newDangerAttack.transform.position.z), Quaternion.Euler(180,0,0));
        Destroy(newDangerAttack, 1f);

        if (GoFaster.SceneTransitionCount > 2)
        {
            StartCoroutine(spawnMissile(rand.GetRandomNumber(missileEndBound - (GoFaster.SceneTransitionCount * 0.5f)), hover, attack)); 
        }

        else {
            StartCoroutine(spawnMissile(rand.GetRandomNumber(missileEndBound), hover, attack)); 
        }
    }
}
