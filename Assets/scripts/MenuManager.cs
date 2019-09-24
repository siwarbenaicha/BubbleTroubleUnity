using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    public GameObject panel;
    public void Start()
    {
        panel.SetActive(false);
    }
  public void PlayGame()
    {
        SceneManager.LoadScene("SampleScene");
        
    }

    public void QuitGame()
    {
        Application.Quit();
        Debug.Log("hello");
    }

    public void ShowPanel()
    {
        panel.SetActive(true);
    }
    public void HidePanel()
    {
        panel.SetActive(false);
        Debug.Log("ok");
    }
}
