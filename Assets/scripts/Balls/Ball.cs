using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    public GameObject nextBall;
    Rigidbody2D rb;
   public bool right;

    Vector2 currentVelocity;
    public GameObject powerUpShield;
    public GameObject powerUpTimeStop;

    private void Awake()
    {
        rb=GetComponent<Rigidbody2D>();
    
    }

    public void Split()
    {
        GameController.instance.updateScore(1);
        if (nextBall != null)
        {
            InstanciatePriZ();
            GameObject ball1 = Instantiate(nextBall, rb.position + Vector2.right / 4, Quaternion.identity);
            GameObject ball2 = Instantiate(nextBall, rb.position + Vector2.left / 4, Quaternion.identity);
            if (!FreezManager.fm.freez) {
            ball1.GetComponent<Rigidbody2D>().isKinematic = false;
            ball1.GetComponent<Rigidbody2D>().AddForce(new Vector2(2, 5), ForceMode2D.Impulse);
            ball1.GetComponent<Ball>().right = true;

            ball2.GetComponent<Rigidbody2D>().isKinematic = false;
            ball2.GetComponent<Rigidbody2D>().AddForce(new Vector2(-2, 5), ForceMode2D.Impulse);
            ball2.GetComponent<Ball>().right = false;

            }
            else
            {
                ball1.GetComponent<Ball>().currentVelocity = new Vector2(2, 5);
                ball2.GetComponent<Ball>().currentVelocity = new Vector2(-2, 5);

            }
            
            BallManager.bm.DestroyBall(gameObject, ball1, ball2);
        }
        else
        {
            BallManager.bm.LastBall(gameObject);
        }
    }
    public void StartForce(params GameObject[] balls)
    {   for(int i=0;i< balls.Length; i++)
        {
           

            if (right)
            {
                balls[i].GetComponent<Rigidbody2D>().isKinematic = false;
                balls[i].GetComponent<Rigidbody2D>().AddForce(new Vector2(4.0f,0.0f),ForceMode2D.Impulse);
            }
            else
            {
                balls[i].GetComponent<Rigidbody2D>().isKinematic = false;
                balls[i].GetComponent<Rigidbody2D>().AddForce(-Vector3.right * 2, ForceMode2D.Impulse);
            }
        }

    }

    public void FreezBall(params GameObject[] balls)
     { foreach( GameObject item in balls)
         {
             if(item != null)
             {
                 currentVelocity = item.GetComponent<Rigidbody2D>().velocity;
                 item.GetComponent<Rigidbody2D>().isKinematic = true;
                 item.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
             }
         }

     }

     public void UnFreezBall(params GameObject[] balls)
     {
         foreach (GameObject item in balls)
         {
             if (item != null)
            {
                item.GetComponent<Rigidbody2D>().isKinematic = false;
                item.GetComponent<Rigidbody2D>().AddForce(currentVelocity,ForceMode2D.Impulse) ;
               
              

             }
         }

     }

    void InstanciatePriZ()
    {
        int aleatory = BallManager.bm.AleatoryNumber();
        int aleatoryObject = BallManager.bm.AleatoryObject();
        if(powerUpShield!=null && powerUpTimeStop != null)
        {
             if (aleatory == 1)
             {
                 if (aleatoryObject == 0)
                 {
                     Instantiate(powerUpShield, transform.position, Quaternion.identity);
                 }
                 if (aleatoryObject == 1)
                 {
                     Instantiate(powerUpTimeStop, transform.position, Quaternion.identity);
                 }

             }
        }
       
    }

}
