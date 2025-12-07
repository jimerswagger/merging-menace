using UnityEngine;

public class missileBoomBoom : MonoBehaviour
{

    //code from this video: https://youtu.be/SKdM2ERWy8U?si=qgirHcpk64xCfzBz

    public GameObject explosion;
    public float explosionForce, radius;

    //[SerializeField] private AudioClip missileBoomSound;



    private void OnCollisionEnter(Collision collision)
    {

        GameObject exp = Instantiate(explosion, transform.position, Quaternion.identity);

        Destroy(exp, 1f);

        knockBack();

        //AudioSource.PlayClipAtPoint(missileBoomSound, transform.position);

        //missileBoomSound.Play(); this doesn't work for some reason
        
        Destroy(gameObject);
    }

    void knockBack()
    {
        //collect all the colliders around us with this domain expansion thing
        Collider[] colliders = Physics.OverlapSphere(transform.position, radius);

        foreach (Collider nearby in colliders)
        {
            Rigidbody rb = nearby.GetComponent<Rigidbody>();

            if (rb != null)
            {
                rb.AddExplosionForce(explosionForce, transform.position, radius);
            }
        }
    }

}
