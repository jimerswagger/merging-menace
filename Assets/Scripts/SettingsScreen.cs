using UnityEngine;
using UnityEngine.SceneManagement;

public class SettingsScreen : MonoBehaviour
{

    public void BackButton()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
