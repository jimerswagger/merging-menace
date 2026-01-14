using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainMenuScreen : MonoBehaviour
{
    public void PlayButton()
    {
        SceneManager.LoadScene("VirginiaStart");
    }

    public void SettingsButton()
    {
        Debug.Log("Settings Button Pressed :)");
        SceneManager.LoadScene("HowToPlay");
    }
}
