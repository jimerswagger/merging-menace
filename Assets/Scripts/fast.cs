using UnityEngine;

public class fast : MonoBehaviour
{

    public int speed = 5;

    void Update()
    {
        transform.position += new Vector3(0, 0, 5) * speed * Time.deltaTime;
    }
}
