using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;


public class TextAnimation : MonoBehaviour
{
    int i = 0;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        this.gameObject.transform.Rotate(0, (float)Math.Abs(Math.Sin(i * (Math.PI / 180)))*5+0.5f,0);
        i++;
    }
}
