using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Valores : MonoBehaviour
{
    public int value;
    public bool one;
    public bool two;
 
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(value>2) { 
            one = false; two = true;
        }
        if(value<-2) {
            one = true; two = false; 
        }
        if(value>=-2 && value<=2) {
            one = false; two = false;
        }
        if (value > 5)
        {
            value = 5;
        }
        if (value<-5)
        { 
            value = -5;
        }

    }
}
