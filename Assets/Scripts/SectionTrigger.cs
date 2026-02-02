using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;

public class SectionTrigger : MonoBehaviour
{

    public GameObject highway;

    private GameObject spawnNewRoadPos;


    void Update()
    {
        spawnNewRoadPos = GameObject.FindGameObjectWithTag("SpawnPos");

        GameObject[] taggedObjects = GameObject.FindGameObjectsWithTag("SpawnPos");

        // Delete Oldest "SpawnPos" tagged Object (one attached to each highway prefab)
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
            Instantiate(highway, new Vector3(spawnNewRoadPos.transform.position.x, spawnNewRoadPos.transform.position.y, spawnNewRoadPos.transform.position.z), Quaternion.identity);
            // Debug.Log("Spawned at: " + spawnNewRoadHere.transform.position);

        }
    }
    


}
