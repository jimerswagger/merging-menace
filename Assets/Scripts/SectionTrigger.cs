using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class SectionTrigger : MonoBehaviour
{

    public GameObject highway;

    private int counter;

    public playerMovement status;

    void Start()
    {
        status = GetComponent<playerMovement>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Trigger"))
        {
            counter++;

            //if (player moving up, then instantiate at a different z value)
            if (status.playerUp)
            {
                Instantiate(highway, new Vector3(0, 0.5f, 48f), Quaternion.identity);
            }

            else
            {
                Instantiate(highway, new Vector3(0, 0.5f, 44f), Quaternion.identity); //make object out of the 'road' prefab
                                                                                      //at this new Vector, new position in 3D space, Quaternion.identity here means no rotation.
                Debug.Log("# Made: " + counter);
                //z is 44f if you're not moving LOL
            }
        }
    }

}
