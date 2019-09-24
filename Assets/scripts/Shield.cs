using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shield : MonoBehaviour
{
    bool inGround;
    private AudioSource audioSource;
   
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (!inGround)
        {
            transform.position += Vector3.down * Time.deltaTime * 2;
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "ground")
        {
            inGround = true;
            Destroy(gameObject, 60);
          
        }

        if (other.gameObject.tag == "Player")
        {
            other.gameObject.GetComponent<PlayerController>().shield.SetActive(true);
            other.gameObject.GetComponent<PlayerController>().blink = false;
            audioSource = GetComponent<AudioSource>();

           
           Destroy(gameObject);
        }
    }
}
