using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class zzzzdeneme : MonoBehaviour
{
    [SerializeField]
    private Rigidbody rb;
    [SerializeField]
    private SpringJoint joint;

    void Start()
    {
        
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            rb.velocity = new Vector3(0, 20, 0);
        }
        if (Input.GetKeyDown(KeyCode.A))
        {
            joint.connectedBody = rb;
        }
        if (Input.GetKeyUp(KeyCode.A))
        {
            joint.connectedBody = null;
        }
    }
}
