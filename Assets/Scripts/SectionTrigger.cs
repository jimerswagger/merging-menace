using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;
using UnityEditor.AnimatedValues;
using UnityEngine;

public class SectionTrigger : MonoBehaviour
{

    public GameObject highway;

    private GameObject spawnNewRoadHere;
    private GameObject spawnNewRoadPos;

    void Start()
    {
        spawnNewRoadHere = GameObject.FindGameObjectWithTag("Spawn");
        //spawnNewRoadPos = GameObject.FindGameObjectWithTag("SpawnPos");
    }

    void Update()
    {
        spawnNewRoadPos = GameObject.FindGameObjectWithTag("SpawnPos");

        GameObject[] taggedObjects = GameObject.FindGameObjectsWithTag("SpawnPos");

        // Deleting Oldest "SpawnPos" tagged Object
        if (taggedObjects.Length > 1)
        {
            Destroy(taggedObjects[0]);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Trigger"))
        {
            // Generate Highway at Invisible Game Object's X and Y position + Current Z when attached to player
            Instantiate(highway, new Vector3(spawnNewRoadPos.transform.position.x, spawnNewRoadPos.transform.position.y, spawnNewRoadHere.transform.position.z), Quaternion.identity);
            Debug.Log("Spawned at: " + spawnNewRoadHere.transform.position);

        }
    }
    


}
