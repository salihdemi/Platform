using UnityEngine.SceneManagement;
using System.Collections.Generic;
using System.Collections;
using UnityEngine.UI;
using UnityEngine;

public class KarakterScript : MonoBehaviour
{
    private float yerCekimiK, xRot, has;

    private bool yerde;

    [SerializeField]
    private GameObject ayarlarPanel;

    [SerializeField]
    private float yerCekimi, hiz, ziplama;

    [SerializeField]
    private Slider sld;

    [SerializeField]
    private Transform cam;

    [SerializeField]
    private Rigidbody rb;
    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        PlayerPrefs.SetInt("Bolum", SceneManager.GetActiveScene().buildIndex);
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }//sahne deðiþtirme 

        //ROTASYON
        float rotX = Input.GetAxisRaw("Mouse X") * has * Time.deltaTime;
        float rotY = Input.GetAxisRaw("Mouse Y") * has * Time.deltaTime;
        


        xRot -= rotY;//hiçbir fikrim yok ama fps kamerayla ilgili ve çok önemli
        xRot = Mathf.Clamp(xRot, -90, 90);//bakýþý kilitler
        cam.localRotation = Quaternion.Euler(xRot, 0, 0);
        transform.Rotate(0, rotX, 0);


        //ÖLDÜRME
        if (transform.position.y<-10)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }



        //YERÇEKÝMÝ
        rb.AddForce(Vector3.up * -yerCekimiK * Time.deltaTime * 100, ForceMode.Force);


        //HAREKET
        float zPos = Input.GetAxis("Vertical");
        float xPos = Input.GetAxis("Horizontal");
        rb.velocity = transform.forward * zPos * hiz * 100 * Time.deltaTime + transform.right * xPos * hiz * 100 * Time.deltaTime + transform.up * rb.velocity.y;


        //ZIPLAMA
        if (yerde && Input.GetKeyDown(KeyCode.Space))
        {
            rb.AddForce(Vector3.up * ziplama * Time.deltaTime * 100, ForceMode.Impulse);
        }

    }
    private void OnCollisionEnter(Collision collision)
    {
        yerCekimiK = 0;
        yerde = true;
        if (collision.transform.tag == "Hareketli")
        {
            transform.SetParent(collision.transform);
        }
        if (collision.transform.tag == "Finish")
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
    }
    private void OnCollisionExit(Collision collision)
    {
        yerCekimiK = yerCekimi;
        yerde = false;
        if (collision.transform.tag == "Hareketli")
        {
            transform.parent.DetachChildren();
        }
    }
    public void HassasiyetDegisim()
    {
        has = sld.value;
    }
}