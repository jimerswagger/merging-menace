using UnityEngine;
using System.Collections;
using NUnit.Framework;

public class Shoot : MonoBehaviour
{

    //code used from this video: https://youtu.be/k1kOtaM2NJg?si=TwEvbT5SiCe5jOCT

    [SerializeField] private float timer = 0.3f;
    private float bulletTime;

    public GameObject enemyBullet;
    public Transform spawnPoint;
    public float enemySpeed;

    private bool isShootingActive = false;
    private float methodExecutionTimer = 0f;
    public float executionDuration = 5f;
    public float cooldownDuration = 2f;



    void Update()
    {
        if (isShootingActive)
        {
            ShootAtPlayer();

            methodExecutionTimer += Time.deltaTime; //keeping track of time with this timer

            if (methodExecutionTimer >= executionDuration) //if time elapsed is greater than the time we want the method to be executing for
            {
                isShootingActive = false; //set bool to false to prevent any further calls to the method
                methodExecutionTimer = 0f; //reset the timer
            }
        }
        else
        {
            methodExecutionTimer += Time.deltaTime;

            if (methodExecutionTimer >= cooldownDuration) //if time elapsed is greater than the time we wanted to not be executing
            {
                isShootingActive = true; //let method execute again
                methodExecutionTimer = 0f; //reset timer
            }
        }
    }

    void ShootAtPlayer()
    {
        bulletTime -= Time.deltaTime;

        if (bulletTime > 0) return;

        bulletTime = timer;

        GameObject bulletObj = Instantiate(enemyBullet, spawnPoint.transform.position, spawnPoint.transform.rotation) as GameObject;
        Rigidbody bulletRig = bulletObj.GetComponent<Rigidbody>();
        bulletRig.AddForce(-bulletRig.transform.right * enemySpeed); //shoot left
        Destroy(bulletObj, 5f);
    }

}
