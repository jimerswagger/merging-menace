using UnityEngine;

public class Health : MonoBehaviour
{

    public GameOverScript gameOverScript;

    public float health = 5.0f;

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Enemy"))
        {
            health -= 1.0f;
            Debug.Log("Health: " + health);
        }
    }

    void Update()
    {
        if (health <= 0.0f)
        {
            gameOverScript.SetUp(2000);
            GoFaster.SceneTransitionCount = 0f;
            Destroy(gameObject);
        }
    }


}
