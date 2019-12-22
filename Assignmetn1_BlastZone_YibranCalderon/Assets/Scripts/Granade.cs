using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Granade : MonoBehaviour
{
    public ParticleSystem smoke;
    public float explosionForce;
    public float explosionRange;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(GranadeTimer()); 
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private IEnumerator Explosion()
    {
        Collider[] colliders = Physics.OverlapSphere(transform.position, explosionRange);
        foreach(Collider collider in colliders)
        {
            Renderer renderer = collider.GetComponent<Renderer>();
            Rigidbody rb = collider.GetComponent<Rigidbody>();
            if (rb != null)
                rb.AddExplosionForce(explosionForce, transform.position, explosionRange, 0, ForceMode.Impulse);
            smoke.Play();
        }
        yield return null;
    }
    private IEnumerator GranadeTimer()
    {
        yield return new WaitForSeconds(2);
        StartCoroutine(Explosion());
        yield return new WaitForSeconds(0.5f);
        Destroy(this.gameObject);
    }
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, explosionRange);
    }
}
