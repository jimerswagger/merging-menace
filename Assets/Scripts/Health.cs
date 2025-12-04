using UnityEngine;

public class Health : MonoBehaviour
{

    public GameOverScript gameOverScript;

    public SceneFader sceneFader;

    public float health = 5.0f;

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Enemy"))
        {
            health -= 1.0f;
            Debug.Log("Health: " + health);
        }

        if (other.gameObject.CompareTag("GoToLA"))
        {
            sceneFader.FadeAndLoad("LosAngeles", 1);
        }

        if (other.gameObject.CompareTag("GoToVA"))
        {
            sceneFader.FadeAndLoad("VirginiaStart", 1);
        }
    }

    void Update()
    {
        if (health <= 0.0f)
        {
            gameOverScript.SetUp(1000);
            Destroy(gameObject);
        }
    }


}
