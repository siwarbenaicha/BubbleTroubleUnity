using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager gm;
    public GameObject ready;
    public GameObject lose;



    public GameObject GameOverPanel;
    void Awake()
    {
        if (gm == null)
        {
            gm = this;
        }
        else if (gm != this)
        {
            Destroy(gameObject);
        }
    }
    void Start()
    {
        StartCoroutine(GameStart());
        
        lose.SetActive(false);
    // GameOverPanel.SetActive(false);
    }
   
    
    void Update()
    {
       
    }

 
    public IEnumerator GameStart()
    {
        yield return new WaitForSeconds(1);
        ready.SetActive(false);
        //  yield return null;
        BallManager.bm.StartGame();
    }

    public void GoToHome()
    {
        SceneManager.LoadScene("MenuSc");
    }
}
