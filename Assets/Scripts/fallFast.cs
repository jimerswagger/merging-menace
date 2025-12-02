using UnityEngine;

public class fallFast : MonoBehaviour
{
    public float downwardForce = 10f; // Adjust this value in the Inspector
    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void FixedUpdate() // Use FixedUpdate for physics operations
    {
        // Apply a continuous downward force
        rb.AddForce(Vector3.down * downwardForce, ForceMode.Acceleration); 
        // ForceMode.Acceleration applies a continuous acceleration to the Rigidbody, ignoring its mass.
        // ForceMode.Force applies a continuous force to the Rigidbody, taking its mass into account.
    }
}

