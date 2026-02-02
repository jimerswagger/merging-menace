using UnityEngine;

public class FixedFollower : MonoBehaviour
{
    //this script will be DELETED after Los Angeles level implements the new highway spawning system
    
    [SerializeField] private Transform player;
    [SerializeField] private Vector3 offset = new Vector3(0, 0, 19f); 
    // 45 units in front of player along world Z

    void LateUpdate() //this means we call this method only after all other Update() methods are called
    // i.e. after the player moves
    {
        // Keep position fixed relative to player and ignore rotation
        Vector3 targetPosition = player.position + offset;
        transform.position = targetPosition; 
        //this script is attached to SpawnPos object
    }
}
