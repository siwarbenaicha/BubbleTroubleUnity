using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DontDestroy : MonoBehaviour
{
    public static DontDestroy dd;
    
   
    void Awake()
    {
        if (dd == null)
        {
            dd = this;
        }
        else if (dd != this)
        {
            Destroy(gameObject);
        }
        DontDestroyOnLoad(gameObject);
       
    }
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
       
       
    }

}
