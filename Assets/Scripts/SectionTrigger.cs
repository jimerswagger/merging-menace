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
            Instantiate(road); //make object out of the 'road' prefab
        }
    }

}
