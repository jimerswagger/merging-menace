using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour
{

    public static int accelerating_speed;

    public playerMovement player;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<playerMovement>();
        accelerating_speed = -12; //smaller negative numbers make road go faster
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
            Destroy(transform.parent.gameObject);
        }
    }
}
