using UnityEngine;
using System.Collections;

public class slow : MonoBehaviour
{

    public float speed = 4.0f;

    private Quaternion initialPose;

    void Start()
    {
        initialPose = Quaternion.Euler(0,0,0);
    }

    void Update()
    {
        transform.position += new Vector3(0, 0, -5) * speed * Time.deltaTime;

        if (transform.rotation != initialPose)
        {
            StartCoroutine(resetPose());
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("DestroyPlayer"))
        {
            Destroy(transform.gameObject);
        }
    }

    IEnumerator resetPose()
    {
        yield return new WaitForSeconds(2.0f);
        transform.rotation = initialPose;
    }
}
