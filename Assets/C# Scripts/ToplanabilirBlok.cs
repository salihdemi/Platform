using System.Collections.Generic;
using System.Collections;
using UnityEngine;

public class ToplanabilirBlok : MonoBehaviour
{
    [SerializeField]
    private Rigidbody rb;
    [SerializeField]
    private Transform karakter, cam;
    private bool elde = false;
    private RaycastHit RayInteract;
    bool hitDetect;
    void Update()
    {
        //Physics.Raycast(karakter.position, out RayInteract, karakter.TransformDirection(Vector3.down),5f);

        if(RayInteract.collider.tag == "Ray")
        {
            hitDetect = true;
        }else
        {
            hitDetect = false;
        }
        Debug.Log(hitDetect);

        if (Input.GetKeyDown(KeyCode.E))
        {
            if (elde)
            {
                transform.parent = null;
                rb.useGravity = true;
                rb.constraints &= RigidbodyConstraints.None;
                elde = false;
            }

            else if (!elde )//direction sýkýntýlý
            {
                rb.useGravity = false;
                rb.constraints = RigidbodyConstraints.FreezeAll;
                transform.SetParent(karakter);
                transform.localPosition = new Vector3(0, -0.4f, 1.5f);
                transform.localRotation = Quaternion.identity;
                elde = true;
            }
        }
    }
}
