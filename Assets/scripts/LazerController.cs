using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LazerController : MonoBehaviour
{
    public Rigidbody2D lazer;
    public float LazerSpeed = 6f;

   AudioSource lazerAudio;


   
   public float nextshoot = 0f;

    void Start()
    {
        
        lazerAudio = GetComponent<AudioSource>();
        lazerAudio.Play();
        lazer.AddForce(Vector2.up * LazerSpeed, ForceMode2D.Impulse);

        
    
        Destroy(gameObject, 8);
    }

   
    void Update()
    {
       
    }



  private  void OnTriggerEnter2D(Collider2D col)
    {

        if (col.gameObject.tag == "Ball")
        {
            col.gameObject.GetComponent<Ball>().Split();
        }
            Destroy(gameObject);
    }

 

}
