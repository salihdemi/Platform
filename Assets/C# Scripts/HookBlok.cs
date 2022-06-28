using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HookBlok : MonoBehaviour
{
    [SerializeField]
    private LayerMask lyr;
    [SerializeField]
    private Rigidbody karakter;
    [SerializeField]
    Transform cam;
    [SerializeField]
    private SpringJoint joint;
    void Start()
    {

    }

    void Update()
    {
        if (Input.GetMouseButtonDown(1) && Physics.Raycast(cam.position, cam.localRotation.eulerAngles, 100, lyr)) 
        {
            joint.connectedBody = karakter;
        }
        if (Input.GetMouseButtonUp(1))
        {
            joint.connectedBody = null;
        }
    }
}
