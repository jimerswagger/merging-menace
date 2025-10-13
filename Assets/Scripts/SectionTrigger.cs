using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEditor.AnimatedValues;
using UnityEngine;

public class SectionTrigger : MonoBehaviour
{

    public GameObject highway;

    public GameObject spawnNewRoad; //invisible

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Trigger"))
        {
            //if (player moving up, then instantiate at a different z value)
            Instantiate(highway, new Vector3(0, 0.5f, 48f), Quaternion.identity);
            //make an invisible game object that is right at the edge of the road, 
            // so you can instantiate a prefab at the position of that invisible object.
            // Instantiate(highway, invisibleGameObject.positionVector3, Quaternion.identity);
        }
    }

}
