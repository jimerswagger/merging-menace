using System.Runtime.CompilerServices;
using NUnit.Framework.Internal;
using UnityEngine;
using TMPro;
using System.Collections;


public class GoFaster : MonoBehaviour
{

    public static float SceneTransitionCount = 0f;

    public static int DisplayScore = 0;

    public TextMeshProUGUI DisplayScoreText;

    private bool scoringRunning = false;


    void Update()
    {

        // If game over screen is active, stop scoring and reset score
        if (GameOverScript.GameOverActive)
        {
            DisplayScore = 0;
            return;
        }

        // Start score loop only once with bool
        if (!scoringRunning)
        {
            StartCoroutine(AddScoreLoop());
        }
        
        DisplayScoreText.text = "Score:\n" + DisplayScore.ToString();
        Debug.Log("Score: " + DisplayScore);

    }


    IEnumerator AddScoreLoop()
    {

        scoringRunning = true;

        while (!GameOverScript.GameOverActive)
        {
            yield return new WaitForSeconds(0.1f);
            DisplayScore += (int)(1 * SceneTransitionCount + 1);
        }

        scoringRunning = false;
    }

}
