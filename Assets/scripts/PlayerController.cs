using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityStandardAssets.CrossPlatformInput;

public class PlayerController : MonoBehaviour
{
    
     Animator animator;
     SpriteRenderer spriteRenderer;
    public float moveSpeed = 2f;

    public GameObject lazer;
    private float nextFire ;
    public bool canShoot = true;

    LazerController lazerCont;
    GameObject mMyClone;

    private AudioSource audioSource;
    public AudioClip deathclip;

    public Joystick joystick;
    float StopLazerGameFinish = 0f;

    public GameObject shield;
    public bool blink;
     Rigidbody2D rb2d;

    //float movement = 0f;
    float newX;
    public bool rightWall;
    public bool leftWall;
    public GameObject myDeadPlayer;
    public GameObject replayBtn;
    private void Awake()
    {
        rb2d = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        replayBtn.SetActive(false);

    }
    void Start()
    {
      lazerCont = lazer.GetComponent<LazerController>();
        //  lazer.gameObject.SetActive(true);
     

    }

    
    void Update()
    {
        if (CrossPlatformInputManager.GetButtonDown("Shoot"))
        {
            animator.SetInteger("state", 1);

        }

        if (CrossPlatformInputManager.GetButtonUp("Shoot"))
        {
            Vector2 lazerpos = new Vector2(transform.position.x, -1.0f);
            if (StopLazerGameFinish == 0)
            {
                Instantiate(lazer, lazerpos, lazer.transform.rotation);

            }

        }
    }

    void FixedUpdate()
    {
     
        Vector3 helloRight = new Vector3(Mathf.Clamp(rb2d.position.x, -5.7f, 5.7f) * moveSpeed, rb2d.transform.position.y, 0.0f);
        Vector3 helloLeft = new Vector3(Mathf.Clamp(rb2d.position.x, -5.7f, 5.7f) * -moveSpeed, rb2d.transform.position.y, 0.0f);

     
        if (joystick.Horizontal >= .2f )
         {
             animator.SetInteger("state", 0);
           
             rb2d.MovePosition(rb2d.position + Vector2.right * moveSpeed * Time.fixedDeltaTime);
            newX = Mathf.Clamp(rb2d.position.x, -6.3f, 6.3f);
             transform.position = new Vector2(newX, transform.position.y);
            spriteRenderer.flipX = false;
         }else if(joystick.Horizontal <= -.2f)
         {
             animator.SetInteger("state", 0);
          
            rb2d.MovePosition(rb2d.position + Vector2.right * -moveSpeed * Time.fixedDeltaTime);
            newX = Mathf.Clamp(rb2d.position.x, -6.3f, 6.3f);
            transform.position = new Vector2(newX, transform.position.y);
            spriteRenderer.flipX = true;
         }
        




    }


   public void ReloadLevel()
     {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
     }
   
      private void OnCollisionEnter2D(Collision2D col)
      {
      }
      void OnTriggerEnter2D(Collider2D col)
      {
        
            if (col.gameObject.tag == "Ball")
            {


                if (shield.activeInHierarchy)
                {
                    shield.SetActive(false);
                    StartCoroutine(Blinking());

                }
                else
                {
                    if (!blink)
                    {

                        StopLazerGameFinish = 1;
                       
                         audioSource = GetComponent<AudioSource>();

                        audioSource.Play();

                        StartCoroutine(Lose());

                        BallManager.bm.LoseGame();

                        GameManager.gm.lose.SetActive(true);
                    //  GameManager.gm.GameOverPanel.SetActive(true);


                    // Invoke("ReloadLevel", 3.0f);
                    replayBtn.SetActive(true);


                    }
                }

            }
        if(col.gameObject.tag == "timeStop")
        {
            FreezManager.fm.StartFreez();
            col.gameObject.SetActive(false);
        }

      }

    public IEnumerator Lose()
    {
        shield.SetActive(false);
        Vector3 playerPos = gameObject.transform.position;
       
        gameObject.GetComponent<Renderer>().enabled = false;
        myDeadPlayer.transform.position = playerPos;
        myDeadPlayer.gameObject.GetComponent<SpriteRenderer>().enabled = true;
        yield return new WaitForSeconds(1);

    }

  

    public IEnumerator Blinking()
    {
        blink = true;
        for(int i=0; i < 8; i++)
        {
            if (blink)
            {
                spriteRenderer.color = new Color(1, 1, 1, 0);
                yield return new WaitForSeconds(0.2f);
                spriteRenderer.color = new Color(1, 1, 1, 1);
                yield return new WaitForSeconds(0.2f);
            }
            else
            {
                break;
            }
        }
        blink = false;
    }

   

}
