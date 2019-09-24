using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    AudioSource gameAudio;
    public int Score;
    public Text ScoreText;


    public int ball2  = 0;
    public int ball1 = 0;
    public static GameController instance;

    

    void Awake()
    {

        // give reference to created object.
        instance = this;

    }
    void Start()
    {
        gameAudio = GetComponent<AudioSource>();
        gameAudio.loop = true;
        gameAudio.Play();

        Score = 0;
        ScoreText.text = "Score:" + Score;

    }

    // Update is called once per frame
    void Update()
    {
      
    }

    public void updateScore(int val)
    {
        Score += val;
        ScoreText.text = "Score:" + Score;

       
    }

   
}
