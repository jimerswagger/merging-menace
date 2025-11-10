using UnityEngine;

public class slow : MonoBehaviour
{

    public int speed = 4;

    void Update()
    {
        transform.position += new Vector3(0, 0, -5) * speed * Time.deltaTime;
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Destroy"))
        {
            Destroy(transform.gameObject);
        }
    }
}
