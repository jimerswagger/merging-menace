using UnityEngine;
using TMPro;

public class Health : MonoBehaviour
{

    public GameOverScript gameOverScript;

    public GameObject DisplayScoreText;

    public GameObject DisplayHealth;

    public TextMeshProUGUI DisplayHealthText;

    public static float health = 5.0f;

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Enemy"))
        {
            health -= 1.0f;
        }
    }

    void Update()
    {

        DisplayHealthText.text = "HP:\n" + health.ToString();

        if (health <= 0.0f)
        {

            DisplayScoreText.SetActive(false);
            DisplayHealth.SetActive(false);

            gameOverScript.SetUp(GoFaster.DisplayScore);
            GoFaster.SceneTransitionCount = 0f;
            GoFaster.DisplayScore = 0;
            fast.speedToAdd = 0f;
            health = 5f;
            Destroy(gameObject);
        }
    }


}
