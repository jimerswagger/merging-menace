using UnityEngine;

public class randomNumberGenerator : MonoBehaviour
{

    // // Update is called once per frame
    // void Update()
    // {
    //     GetRandomNumber(endBound);
    // }

    public float GetRandomNumber(float end)
    {
        float number = Random.Range(1f, end);
        return number;
    }

}
