using UnityEngine.SceneManagement;
using System.Collections.Generic;
using System.Collections;
using UnityEngine;

public class MenuScript : MonoBehaviour
{
    [SerializeField]
    private GameObject panel;
    public void YeniOyun()
    {
        SceneManager.LoadScene(1);
    }
    public void Cikis()
    {
        Application.Quit();
    }
    public void DevamEt()
    {
        SceneManager.LoadScene(PlayerPrefs.GetInt("Bolum"));
    }
    public void Ayarlar()
    {
        panel.SetActive(true);
    }
}
