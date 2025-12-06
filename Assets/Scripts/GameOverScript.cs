using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class GameOverScript : MonoBehaviour
{
    //Code modified from this video: https://youtu.be/K4uOjb5p3Io?si=LMrAo3iwJf9ciGEd

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
        Invoke(nameof(HideGameOverScreen), 0.8f);
        SceneManager.LoadScene(currentScene.name);
    }

    public void MainMenuButton()
    {
        Invoke(nameof(HideGameOverScreen), 0.8f);
        SceneManager.LoadScene("MainMenu");
    }

    public void HideGameOverScreen()
    {
        gameObject.SetActive(false); //have gameover screen be off at start
    }

}
