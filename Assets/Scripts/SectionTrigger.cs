using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEditor.AnimatedValues;
using UnityEngine;

public class SectionTrigger : MonoBehaviour
{

    public GameObject highway;

    private GameObject spawnNewRoadHere;

    void Start()
    {
        spawnNewRoadHere = GameObject.FindGameObjectWithTag("Spawn");
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Trigger"))
        {
            // Generate Highway at Invisible Game Object
            Instantiate(highway, spawnNewRoadHere.transform.position, Quaternion.identity);
            Debug.Log("Spawned at: " + spawnNewRoadHere.transform.position);
            
        }
    }

}
