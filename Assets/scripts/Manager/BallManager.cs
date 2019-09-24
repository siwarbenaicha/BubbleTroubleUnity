using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallManager : MonoBehaviour
{
    public static BallManager bm;
    public List<GameObject> balls = new List<GameObject>();
    void Awake()
    {
        if (bm == null)
        {
            bm = this;
        }
        else if (bm != this)
        {
            Destroy(gameObject);
        }
    }
    void Start()
    {
      
        balls.AddRange(GameObject.FindGameObjectsWithTag("Ball"));
       // StartGame();
    }

    
    void Update()
    {
        if (balls.Count == 0 && BallSpawn.bs.free)
        { if(GameController.instance.Score == 7 || GameController.instance.Score == 21)
            {
                BallSpawn.bs.newBallRight();
                BallSpawn.bs.newBallLeft();

            }else if (GameController.instance.Score ==0)
            {
                BallSpawn.bs.newBall();
               
            }
            else
            {
                BallSpawn.bs.newBallRight();
                BallSpawn.bs.newBallLeft();
                BallSpawn.bs.newBallMiddle();
            }
          
           // BallSpawn.bs.newBall();
        }
    }


    public void StartGame()
    {
        foreach (GameObject item in balls)
        {
            
            if (balls.IndexOf(item) % 2 == 0)
            {
                item.GetComponent<Ball>().right = true;
            }
            else
            {
                item.GetComponent<Ball>().right = false;
            }
            item.GetComponent<Ball>().StartForce(item);
        }
    }

    public void LoseGame()
    {
        FreezManager.fm.freezTimeCount.SetActive(false);
        foreach (GameObject item in balls)
        {
            item.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
            item.GetComponent<Rigidbody2D>().isKinematic = true;
        }
    }
    public void DestroyBall(GameObject ball ,GameObject ball1, GameObject ball2)
    {
        balls.Remove(ball);
        Destroy(ball);
       
        balls.Add(ball1);
        balls.Add(ball2);
    }

    public void LastBall(GameObject ball)
    {
        balls.Remove(ball);
        Destroy(ball);
        
    }

    public int AleatoryNumber()
    {
        return Random.Range(0, 2);
    }
    public int AleatoryObject()
    {
        return Random.Range(0, 2);
    }
}
