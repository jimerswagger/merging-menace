using UnityEngine;

public class Health : MonoBehaviour
{

    public float health = 5.0f;

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Enemy"))
        {
            // transform.Rotate(100.0f, 0.0f, 0.0f, Space.Self);
            health -= 1.0f;
            Debug.Log("Health: " + health);
        }
    }

    void Update()
    {
        if (health == 0.0f)
        {
            Destroy(gameObject);
        }
    }


}
