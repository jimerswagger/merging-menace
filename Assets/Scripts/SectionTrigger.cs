using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEditor.AnimatedValues;
using UnityEngine;

public class SectionTrigger : MonoBehaviour
{

    public GameObject highway;

    public GameObject spawnNewRoadHere; //invisible box

    void Start()
    {
        spawnNewRoadHere = GameObject.FindGameObjectWithTag("Spawn");
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Trigger"))
        {
            //if (player moving up, then instantiate at a different z value)
            Instantiate(highway, spawnNewRoadHere.transform.position, Quaternion.identity);
            Debug.Log("Spawned at: " + spawnNewRoadHere.transform.position);
            //make an invisible game object that is right at the edge of the road, 
            // so you can instantiate a prefab at the position of that invisible object.
        }
    }

}
