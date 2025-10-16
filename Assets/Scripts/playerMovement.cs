using Unity.VisualScripting;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class playerMovement : MonoBehaviour
{

    public int speed = 5;

    private PlayerInput playerInput;

    private Move moveObject;

    public InputAction moveAction;



    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        playerInput = GetComponent<PlayerInput>();
        moveObject = GetComponent<Move>();
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

        if (direction.x > 0) //if moving right
        {
            transform.position += new Vector3(direction.x + 1, 0, direction.y) * speed * Time.deltaTime; //sharp right movement
        }

        else if (direction.x < 0) //if moving left
        {
            transform.position += new Vector3(direction.x - 1, 0, direction.y) * speed * Time.deltaTime; //sharp left movement
        }

        else if (direction.y > 0) //if moving up, figure out how to expand condition so it also considers left-up, right-up inputs
        {
            //make road generate faster
            //moveObject.accelerating_speed -= 5;
            Move.accelerating_speed = -15;
            transform.position += new Vector3(direction.x, 0, direction.y - 0.5f) * speed * Time.deltaTime;
        }

        else if (direction.y < 0) //if moving up, figure out left-down, left-right
        {
            transform.position += new Vector3(direction.x, 0, direction.y - 1) * speed * Time.deltaTime;
        }

        else
        {
            transform.position += new Vector3(direction.x, 0, direction.y) * speed * Time.deltaTime;
        }


        //if the player is accelerating forwards
        //then have road.accelerating_speed += 10 to make procedural generation faster

    }
}
