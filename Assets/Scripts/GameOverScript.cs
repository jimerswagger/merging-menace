using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class GameOverScript : MonoBehaviour
{

    public TextMeshProUGUI pointsText;

    public Scene currentScene;

    void Start()
    {
        currentScene = SceneManager.GetActiveScene();
    }

    public void SetUp(int score)
    {
        gameObject.SetActive(true);
        pointsText.text = "Score: " + score.ToString();
    }

    public void RestartButton()
    {
        SceneManager.LoadScene(currentScene.name);
    }

    public void MainMenuButton()
    {
        SceneManager.LoadScene("MainMenu");
    }

}
