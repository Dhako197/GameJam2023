using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Valores : MonoBehaviour
{
    public int valueA;
    public int valueB;
    public int valueC;
    public bool A1;
    public bool A2;   
    public bool B1;
    public bool B2;
    public bool C1;
    public bool C2;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(valueA>2) { 
            A1 = false; A2 = true;
        }
        if(valueA<-2) {
            A1 = true;A2 = false; 
        }
        if(valueA>=-2 && valueA<=2) {
            A1 = false; A2 = false;
        }
        if(valueA>5)
        {
            valueA = 5;
        }
        if(valueA<-5)
        { 
            valueA = -5;
        }


        if (valueB > 2)
        {
            B1 = false; B2 = true;
        }
        if (valueB < -2)
        {
            B1 = true; B2 = false;
        }
        if (valueB >= -2 && valueB <= 2)
        {
            B1 = false; B2 = false;
        }
        if (valueB > 5)
        {
            valueB = 5;
        }
        if (valueB < -5)
        {
            valueB = -5;
        }

        if (valueC > 2)
        {
            C1 = false; C2 = true;
        }
        if (valueC < -2)
        {
            C1 = true; C2 = false;
        }
        if (valueC >= -2 && valueC <= 2)
        {
            C1 = false; C2 = false;
        }
        if (valueC > 5)
        {
            valueC = 5;
        }
        if (valueC < -5)
        {
            valueC = -5;
        }

    }
}
