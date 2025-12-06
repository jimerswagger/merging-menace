using System.Collections;
using System.Collections.Generic;
using System.Data;
using UnityEngine;

public class Move : MonoBehaviour
{
    //used to move the prefab being generated/instantiated towards the player (-z value)

    public float accelerating_speed;

    public playerMovement player;

    public GameObject playerObj;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<playerMovement>();
        accelerating_speed = -12; //smaller negative numbers make road go faster

        if (player == null)
        {
            GameObject newPlayer = Instantiate(playerObj, new Vector3(1.63f, 1f, -4.44f), Quaternion.identity);
        }
    }

    void Update()
    {
        transform.position += new Vector3(0, 0, accelerating_speed) * Time.deltaTime;

        StartCoroutine(AddSpeed());

    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Destroy"))
        {
            Destroy(transform.parent.gameObject);
        }
    }

    IEnumerator AddSpeed()
    {
        yield return new WaitForSeconds(10f);
        accelerating_speed -= .05f;

        //After player survives 2 cities, increase speed that road moves towards player
        if (GoFaster.SceneTransitionCount > 2)
        {
            accelerating_speed -= GoFaster.SceneTransitionCount * 0.0001f;
        }
    }
}
