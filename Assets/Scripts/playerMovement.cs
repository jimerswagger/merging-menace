using Unity.VisualScripting;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class playerMovement : MonoBehaviour
{

    public int speed = 5;

    public PlayerInput playerInput;

    public InputAction moveAction;

    //public Move road;

    public bool playerUp; //is player moving up


    //InputAction jumpAction;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        playerInput = GetComponent<PlayerInput>();
        //road = GetComponent<Move>(); move component/script is on the road prefabs not the player, which is where THIS script is attached to
        moveAction = playerInput.actions.FindAction("Move");
    }

    // Update is called once per frame
    void Update()
    {
        MovePlayer();
    }

    void MovePlayer()
    {

        Vector2 direction = moveAction.ReadValue<Vector2>();
        transform.position += new Vector3(direction.x, 0, direction.y) * speed * Time.deltaTime;


        if (direction == Vector2.up)
        {
            playerUp = true;
            //road.accelerating_speed -= 20;
        }

        else
        {
            playerUp = false;
        }
        //if the player is accelerating forwards
        //then do road.accelerating_speed += speed or something

    }
}
