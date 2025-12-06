using Unity.VisualScripting;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class playerMovement : MonoBehaviour
{

    public int speed = 5;

    private PlayerInput playerInput;

    public InputAction moveAction;

    private Quaternion initialPose;

    public GameOverScript gameOverScript;

    public SceneFader sceneFader;

    void Start()
    {
        playerInput = GetComponent<PlayerInput>();
        moveAction = playerInput.actions.FindAction("Move");
        initialPose = transform.rotation; //getting initial pose of player
    }

    void Update()
    {
        MovePlayer();

        if (transform.rotation != initialPose)
        {
            StartCoroutine(resetPose());
        }
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

        else if (direction.y > 0) //if moving up
        {
            transform.position += new Vector3(direction.x, 0, direction.y + 1.0f) * speed * Time.deltaTime;
        }

        else if (direction.y < 0) //if moving down
        {
            transform.position += new Vector3(direction.x, 0, direction.y - 1.0f) * speed * Time.deltaTime;
        }

        else
        {
            transform.position += new Vector3(direction.x, 0, direction.y-0.2f) * speed * Time.deltaTime;
        }
    }

    IEnumerator resetPose()
    {
        yield return new WaitForSeconds(3.0f);
        transform.rotation = initialPose;
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("DestroyPlayer"))
        {
            gameOverScript.SetUp(1000);
            GoFaster.SceneTransitionCount = 0f;
            Destroy(gameObject);
        }

        if (other.gameObject.CompareTag("GoToLA"))
        {
            GoFaster.SceneTransitionCount += 1f;
            Debug.Log("Scenes Cleared: " + GoFaster.SceneTransitionCount);
            sceneFader.FadeAndLoad("LosAngeles", 1);
        }

        if (other.gameObject.CompareTag("GoToVA"))
        {
            GoFaster.SceneTransitionCount += 1f;
            Debug.Log("Scenes Cleared: " + GoFaster.SceneTransitionCount);
            sceneFader.FadeAndLoad("VirginiaStart", 1);
        }
    }
}
