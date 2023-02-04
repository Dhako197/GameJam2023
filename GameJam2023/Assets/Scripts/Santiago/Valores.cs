using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Valores : MonoBehaviour
{
    public int value;
    public bool one;
    public bool two;
    public Slider slide1;
    public Slider slide2;
    public Image Fill1;
    public Image Fill2;
    private Color blue= Color.blue;
    private Color pink = new Color(255f, 0f, 215f, 255f);
    private Color black = Color.black;
    public Text number1;
    public Text number2;
    public Text number3;
    
 
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(value>2) { 
            one = false; two = true; Fill2.color = pink; Fill1.color = pink; number2.text = value.ToString(); number1.text = ""; number3.text = ""; 
        }
        if(value<-2) {
            one = true; two = false; Fill1.color = blue; Fill2.color = blue; number1.text = (-value).ToString(); number2.text = ""; number3.text = ""; 
        }
        if(value>=-2 && value<=2) {
            one = false; two = false; Fill2.color = black; Fill1.color = black; 
            if(value == 0)
            {
                number3.text = "0"; number2.text = ""; number1.text = "";
            }
            else if(value<0) { number3.text = ""; number1.text = (-value).ToString(); number2.text = ""; }
            else if(value>0) { number3.text = ""; number1.text = ""; number2.text = value.ToString(); }
        }
        if (value > 5)
        {
            value = 5;
        }
        if (value<-5)
        { 
            value = -5;
        }

        slide1.value = -value;
        slide2.value = value ;

    }
}
