using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour
{

    private int accelerating_speed;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        accelerating_speed = -10; //smaller negative numbers make road go faster
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += new Vector3(0, 0, accelerating_speed) * Time.deltaTime;
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Destroy"))
        {
            Destroy(gameObject);
        }
    }
}
