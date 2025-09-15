using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class playerMovement : MonoBehaviour
{

    public Rigidbody rb;

    public float moveSpeed;

    private Vector3 _moveDir;

    public InputAction moveAction; //not sure if its storing 
                                   // the current key that has an action within the larger action of 'move'

    //InputAction jumpAction;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        _moveDir = InputSystem.actions.FindAction("Move").ReadValue<Vector3>(); //like getcomponent
    }

    private void FixedUpdate()
    {
        rb.velocity = new Vector3(_moveDir * moveSpeed, _moveDir * moveSpeed, _moveDir * moveSpeed);
    }
}
