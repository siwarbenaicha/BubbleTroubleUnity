using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallSpawn : MonoBehaviour
{
    public static BallSpawn bs;
    public GameObject[] ballsPrefab;
    GameObject ball = null;
    public bool free;
    void Awake()
    {
        if (bs == null)
        {
            bs = this;
        }
        else if (bs != this)
        {
            Destroy(gameObject);
        }
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(ball!=null && ball.transform.position.y <= 4.4f && !free)
        {
            free = true;
              ball.GetComponent<Ball>().StartForce(ball);
           
        }
    }

    public void newBall()
    {
       
        if (!FreezManager.fm.freez)
         {
        ball = Instantiate(ballsPrefab[Random.Range(0, ballsPrefab.Length)],
            new Vector2(AleatoryPosition(),4.0f), Quaternion.identity);
            
            ball.GetComponent<Rigidbody2D>().isKinematic = false;
            BallManager.bm.balls.Add(ball);
            
            StartCoroutine(moveDown());
        }
    }
    public void newBallRight()
    {
       
        if (!FreezManager.fm.freez)
        {
        ball = Instantiate(ballsPrefab[Random.Range(0, ballsPrefab.Length)],
            new Vector2(Random.Range(-6.3f, -1.0f), 4.0f), Quaternion.identity);
            
            ball.GetComponent<Rigidbody2D>().isKinematic = false;
            BallManager.bm.balls.Add(ball);
        StartCoroutine(moveDown());
       }
    }
    public void newBallLeft()
    {
      
        if (!FreezManager.fm.freez)
        {
        ball = Instantiate(ballsPrefab[Random.Range(0, ballsPrefab.Length)],
            new Vector2(Random.Range(1.0f, 6.3f), 4.0f), Quaternion.identity);
           
         ball.GetComponent<Rigidbody2D>().isKinematic = false;
        BallManager.bm.balls.Add(ball);
        StartCoroutine(moveDown());
       }
    }
    public void newBallMiddle()
    {
        
        if (!FreezManager.fm.freez)
        {
        ball = Instantiate(ballsPrefab[Random.Range(0, ballsPrefab.Length)],
            new Vector2(Random.Range(-0.9f,0.9f), 4.0f), Quaternion.identity);
           
           ball.GetComponent<Rigidbody2D>().isKinematic = false;
            BallManager.bm.balls.Add(ball);
        StartCoroutine(moveDown());
        }
    }
    float AleatoryPosition()
    {
        return Random.Range(-4.0f, 5.7f);
    }
    void OnTriggerStay2D(Collider2D other)
    {
        if (other.gameObject.tag == "Ball")
        {
            free = false;
        }
    }

    IEnumerator moveDown()
    {
        yield return new WaitForSeconds(1);
        while (!free)
        {
            ball.transform.position = new Vector2(ball.transform.position.x, ball.transform.position.y - 0.5f);
           // ball.GetComponent<Rigidbody2D>().AddForce(new Vector2(4.0f, 0.0f), ForceMode2D.Impulse);
            yield return new WaitForSeconds(1);
        }
    }
  
}
