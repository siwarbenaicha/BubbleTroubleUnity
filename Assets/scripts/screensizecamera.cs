using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class screensizecamera : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Camera.main.aspect = 1280f / 720f;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
