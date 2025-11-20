using UnityEngine;
using System.Collections;

public class fast : MonoBehaviour
{

    public int speed = 5;

    private Quaternion initialPose;

    void Start()
    {
        initialPose = Quaternion.Euler(0,0,0);
    }

    void Update()
    {
        transform.position += new Vector3(0, 0, 5) * speed * Time.deltaTime;

        if (transform.rotation != initialPose)
        {
            StartCoroutine(resetPose());
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Destroy"))
        {
            Destroy(transform.gameObject);
        }
    }

    IEnumerator resetPose()
    {
        yield return new WaitForSeconds(0.5f);
        transform.rotation = initialPose;
    }
}
