using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
    public GameObject beamRenderer;
    public GameObject granadePre;
    public float beamForce;
    public float granadeForce;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse1))
        {
            StartCoroutine(BeamShooted());
        }
        BoomShooted();
    }
    private void BoomShooted()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            GameObject bomb = Instantiate(granadePre, transform.position, Quaternion.identity);

            Rigidbody rb = bomb.gameObject.GetComponent<Rigidbody>();

            rb.AddForce(transform.forward * granadeForce, ForceMode.Impulse);
        }
    }
    private IEnumerator BeamShooted()
    {
        RaycastHit[] hits = Physics.RaycastAll(transform.position, transform.forward);
        for (int i = 0; i < hits.Length; i++)
        {
            RaycastHit hit = hits[i];
            Renderer renderer = hit.collider.gameObject.GetComponent<Renderer>();
            Rigidbody rb = hit.collider.gameObject.GetComponent<Rigidbody>();
            if (rb != null)
            
                rb.AddForceAtPosition(transform.forward * beamForce, hit.point, ForceMode.Impulse);
            beamRenderer.SetActive(true);

            yield return new WaitForSeconds(0.1f);

            beamRenderer.SetActive(false);
        }
        yield return null;
    }
}
