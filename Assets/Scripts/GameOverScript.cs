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

    public static bool GameOverActive = false;


    void Start()
    {
        currentScene = SceneManager.GetActiveScene();
        GameOverActive = false;
    }

    public void SetUp(int score)
    {
        GameOverActive = true;
        gameObject.SetActive(true);
        pointsText.text = "Score: " + score.ToString();
    }

    public void RestartButton()
    {
        GoFaster.DisplayScore = 0;
        GameOverActive = false;
        Invoke(nameof(HideGameOverScreen), 0.8f);
        SceneManager.LoadScene(currentScene.name);
    }

    public void MainMenuButton()
    {
        GoFaster.DisplayScore = 0;
        GameOverActive = false;
        Invoke(nameof(HideGameOverScreen), 0.8f);
        SceneManager.LoadScene("MainMenu");
    }

    public void HideGameOverScreen()
    {
        gameObject.SetActive(false); //have gameover screen be off at start
    }

}
