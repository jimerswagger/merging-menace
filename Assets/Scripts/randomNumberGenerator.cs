using UnityEngine;

public class randomNumberGenerator : MonoBehaviour
{
    public float GetRandomNumber(float end)
    {
        float number = Random.Range(1f, end);
        return number;
    }

}
