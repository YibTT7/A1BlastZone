using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Torret : MonoBehaviour
{
    public GameObject gravityZeroPrefab;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        TCamera();
    }
    private void TCamera()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit))
        {
            transform.LookAt(hit.point);

        }

        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            GameObject gravityZero = Instantiate(gravityZeroPrefab, hit.point, Quaternion.identity);
        }





    }
}

