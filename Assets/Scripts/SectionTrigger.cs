using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class SectionTrigger : MonoBehaviour
{

    public GameObject road; //the road prefab, not sure if this prefab will include more than one road

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Trigger"))
        {
            Instantiate(road, new Vector3(0, 0, 32.4f), Quaternion.identity); //make object out of the 'road' prefab
            //at this new Vector, new position in 3D space, Quaternion.identity here means no rotation.
        }
    }

}
