using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour
{
    //used to move the prefab being generated/instantiated towards the player (-z value)

    public static int accelerating_speed;

    public playerMovement player;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<playerMovement>();
        accelerating_speed = -15; //smaller negative numbers make road go faster
    }

    void Update()
    {
        transform.position += new Vector3(0, 0, accelerating_speed) * Time.deltaTime;
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Destroy"))
        {
            Destroy(transform.parent.gameObject);
        }
    }
}
