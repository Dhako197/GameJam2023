using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PowerCooldown : MonoBehaviour
{
    public Slider slide1;
    public GameObject slideobject1;
    public Slider slide2;
    public GameObject slideobject2;
    private Valores valuescript;
    public float cooldown;
    public bool tired;
    public float RestTime;
    public float RecoverTime;
    public float x;
    public Image Fill1;
    public Image Fill2;
    private Color green = Color.green;
    private Color orange = new Color(255f, 135f, 0f, 255f);
    private Color red = Color.red;
    
    // Start is called before the first frame update
    void Start()
    {
        valuescript = this.gameObject.GetComponent<Valores>();
        
    }

    // Update is called once per frame
    void Update()

    {
        x = slide1.value;
        if(valuescript.one==true)
        {
            slideobject1.SetActive(true);
        }
        if(valuescript.one == false)
        { slideobject1.SetActive(false); }
        if(valuescript.two == true)
        { slideobject2.SetActive(true); }
        if(valuescript.two == false) { slideobject2.SetActive(false); }
        
        if(tired == false && slide1.value <=99 && slide1.value >1)
        { 
            slide1.value += 1;
            tired = true;
            Recover();
        }
        if (tired == false && slide1.value <= 1)
        {
            tired = true;
            slide1.value +=2;
            Rest();
        }
        if (tired == false && slide2.value <= 99 && slide2.value > 1)
        {
            slide2.value += 1;
            tired = true;
            Recover();
        }
        if (tired == false && slide2.value <= 1)
        {
            tired = true;
            slide2.value += 2;
            Rest();
        }
        if(slide1.value>30)
        { Fill1.color = green; }
        if(slide1.value<=30 && slide1.value >1)
        { Fill1.color = orange; }
        if(slide1.value <=1)
        { Fill1.color = red; }

        if (slide2.value > 30)
        { Fill2.color = green; }
        if (slide2.value <= 30 && slide2.value > 1)
        { Fill2.color = orange; }
        if (slide2.value <= 1)
        { Fill2.color = red; }
    }

    public void Rest()
    {
        StartCoroutine(WaitThenRest());
    }
    IEnumerator WaitThenRest()
    {
        yield return new WaitForSeconds(RestTime);
        tired = false;
    }

    public void Recover()
    {
        StartCoroutine(WaitThenRecover());
    }
    IEnumerator WaitThenRecover()
    {
        yield return new WaitForSeconds(RecoverTime);
        tired = false;
    }
}
