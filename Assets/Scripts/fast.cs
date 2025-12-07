using UnityEngine;
using System.Collections;

public class fast : MonoBehaviour
{

    public float speed = 5.0f;

    public static float speedToAdd;

    private Quaternion initialPose;

    void Start()
    {
        initialPose = Quaternion.Euler(0,0,0);
    }

    void Update()
    {
        transform.position += new Vector3(0, 0, 5) * speed * Time.deltaTime;

        speedToAdd += Time.deltaTime;

        StartCoroutine(AddSpeed());

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

    IEnumerator AddSpeed()
    {
        yield return new WaitForSeconds(1f);
        speed += speedToAdd * .00000005f + .001f;
    }
}
