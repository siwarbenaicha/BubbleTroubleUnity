
using UnityEngine;

public class BallController : MonoBehaviour
{
    public Vector2 startForce;
    public GameObject nextBall;
    public Rigidbody2D rb;

    AudioSource exlosionAudio;
    public Renderer rend;

    
    
   
   
 
    void Start()
    {
        rb.AddForce(startForce, ForceMode2D.Impulse);
       exlosionAudio =GetComponent<AudioSource>();
        rend = GetComponent<Renderer>();
        rend.enabled = true;

  
      
    }
    void Update()
    {
        
    }

    public void Split()
    {
       
        
        if (nextBall != null)
        {
        
            GameObject ball1 = Instantiate(nextBall, rb.position + Vector2.right / 4f, Quaternion.identity);
            GameObject ball2 = Instantiate(nextBall, rb.position + Vector2.left / 4f, Quaternion.identity);

            ball1.GetComponent<BallController>().startForce = new Vector2(2f, 5f);
            ball2.GetComponent<BallController>().startForce = new Vector2(-2f, 5f);
        }
      
        AudioSource audio = GetComponent<AudioSource>();
        audio.Play();
        rend.enabled = false;
        Destroy(gameObject, audio.clip.length);
      
    }

    public void Split_02()
    {


        if (nextBall != null)
        {

            GameObject ball1 = Instantiate(nextBall, rb.position + Vector2.right / 4f, Quaternion.identity);
            GameObject ball2 = Instantiate(nextBall, rb.position + Vector2.left / 4f, Quaternion.identity);

            ball1.GetComponent<BallController>().startForce = new Vector2(2f, 5f);
            ball2.GetComponent<BallController>().startForce = new Vector2(-2f, 5f);
        }

        AudioSource audio = GetComponent<AudioSource>();
        audio.Play();
        rend.enabled = false;
        Destroy(gameObject, audio.clip.length);

    }
    public void Split_03()
    {



        AudioSource audio = GetComponent<AudioSource>();
        audio.Play();
        rend.enabled = false;
        Destroy(gameObject, audio.clip.length);

    }
}
