using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class SectionTrigger : MonoBehaviour
{

    public GameObject highway; //the highway prefab

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Trigger"))
        {
            Instantiate(highway, new Vector3(0, 0.5f, 44f), Quaternion.identity); //make object out of the 'road' prefab
            //at this new Vector, new position in 3D space, Quaternion.identity here means no rotation.
        }
    }

}
