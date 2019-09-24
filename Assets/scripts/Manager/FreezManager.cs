using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FreezManager : MonoBehaviour
{

    public static FreezManager fm;

    public Text freezTimeText;
    public GameObject freezTimeCount;
    public float freezTime;
    public bool freez;

    void Awake()
    {
        if (fm == null)
        {
            fm = this;
        }
        else if (fm != this)
        {
            Destroy(gameObject);
        }
    }
    void Start()
    {
        freezTimeCount.SetActive(false);
    }

    
    void Update()
    {
        
    }

    public void StartFreez()
    {
        freezTime = 13f;

        if (!freez)
        {
            StartCoroutine(FreezTime());
        }
    }

    public IEnumerator FreezTime()
    {
        freez = true;

        foreach(GameObject item in BallManager.bm.balls)
        {
            if (item != null)
            {
                item.GetComponent<Ball>().FreezBall(item);

            }
               
        }
        freezTimeCount.SetActive(true);
        while (freezTime > 0)
        {
            freezTime -= Time.deltaTime;
            freezTimeText.text = "FreezeTime: "+freezTime.ToString("f2");//f2 2 décimals
            yield return null;


        }
        freezTimeCount.SetActive(false);
        freezTime = 0;
        foreach (GameObject item in BallManager.bm.balls)
        { if(item != null)
            {
                item.GetComponent<Ball>().UnFreezBall(item);
            }
            
        }
        freez = false;
    }
}
