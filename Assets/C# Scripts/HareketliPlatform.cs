using System.Collections.Generic;
using System.Collections;
using UnityEngine;

public class HareketliPlatform : MonoBehaviour
{
    [SerializeField]
    private float hiz, x, y, z;
    private Vector3 pos,ciz;

    private void OnValidate()
    {
        if (ciz != null)
        {
            ciz = transform.position;
        }
    }

    private void Start()
    {
        pos = transform.position;
    }


    void Update()
    {
        float sin = Mathf.Sin(Time.time * Mathf.Deg2Rad * hiz);
        transform.position = new Vector3(pos.x + sin * x, pos.y + sin * y, pos.z + sin * z);
    }
    private void OnDrawGizmos()
    {
        Debug.DrawLine(new Vector3(ciz.x + x, ciz.y + y, ciz.z + z), new Vector3(ciz.x - x, ciz.y - y, ciz.z - z), Color.white);
    }
}