using UnityEngine.SceneManagement;
using System.Collections.Generic;
using System.Collections;
using UnityEngine.UI;
using UnityEngine;

public class Ayarlar : MonoBehaviour
{
    [SerializeField]
    private GameObject panel;
    [SerializeField]
    private Slider has, ses, muz;
    void Start()
    {
        has.value = PlayerPrefs.GetFloat("has");
        ses.value = PlayerPrefs.GetFloat("ses");
        muz.value = PlayerPrefs.GetFloat("muz");
    }

    void Update()
    {

        if (Input.GetKeyDown(KeyCode.G))
        {
            if (panel.activeSelf)
            {
                Cikis();
            }
            else
            {
                panel.SetActive(true);
                Cursor.lockState = CursorLockMode.None;
                Time.timeScale = 0;
            }
        }
    }
    private void Kaydet()
    {
        PlayerPrefs.SetFloat("has", has.value);
        PlayerPrefs.SetFloat("ses", ses.value);
        PlayerPrefs.SetFloat("muz", muz.value);
    }
    public void Cikis()
    {
        panel.SetActive(false);
        Time.timeScale = 1;
        Kaydet();
        if (SceneManager.GetActiveScene().buildIndex != 0)
        {
            Cursor.lockState = CursorLockMode.Locked;
        }
    }
}
