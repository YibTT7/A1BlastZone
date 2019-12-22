using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GravityZero : MonoBehaviour
{
    Vector3 GBox = Vector3.one * 3;
    public float GForce;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Gtime());
    }

    // Update is called once per frame
    void Update()
    {
        StartCoroutine(Gravity());
    }
    private IEnumerator Gravity()
    {
        Collider[] colliders = Physics.OverlapBox(transform.position, GBox / 2);
        foreach (Collider collider in colliders)
        {
            Renderer renderer = collider.GetComponent<Renderer>();
            Rigidbody rb = collider.GetComponent<Rigidbody>();        
            if (rb != null)
                rb.AddForce(transform.up * GForce, ForceMode.Impulse);
        }
        yield return null;
    }
    private IEnumerator Gtime()
    {
        yield return new WaitForSeconds(5);
        Destroy(this.gameObject);
    }
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireCube(transform.position, GBox);
    }
}
