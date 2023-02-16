using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Heritage : MonoBehaviour
{
    public Image infoimg;
    public Color sepia;
    public Color noColor = new Color(255f, 255f, 255f, 0f);
    public Color Visible = new Color(255f, 255f, 255f, 255f);
    public int lifespan;
    public int currentlife;
    public bool playing;
    public GameObject valorA;
    Valores scriptA;
   // public GameObject valorB;
   // Valores scriptB;
    public GameObject valorC;
    Valores scriptC;
    public int uporlow;
    public int result;
    public bool infoing;
    public int ggenerations;
    DisplayName names;
   /* public GameObject young;
    public GameObject adult;
    public GameObject elder;*/
    // Start is called before the first frame update
    void Start()
    {
        names = this.gameObject.GetComponent<DisplayName>();
       // spr = backg.gameObject.GetComponent<SpriteRenderer>();
        infoimg.color = noColor;
        infoing = false;
        ggenerations = 1;
        
        scriptA = valorA.gameObject.GetComponent<Valores>();
       // scriptB = valorB.gameObject.GetComponent<Valores>();
        scriptC = valorC.gameObject.GetComponent<Valores>();
        Life();
    }

    // Update is called once per frame
    void Update()
    {
        if (currentlife == lifespan) { currentlife= 0; Trascend(); ggenerations++; }
        PlayerPrefs.SetInt("generations", ggenerations);
        /* if (currentlife < 23) { young.SetActive(true);adult.SetActive(false);elder.SetActive(false); }
         else if(currentlife < 48) { young.SetActive(false);adult.SetActive(true);elder.SetActive(false); }
         else { young.SetActive(false);adult.SetActive(false);elder.SetActive(true); }*/
    }

    public void Life()
    {
        StartCoroutine(WaitThenStart());
    }
    IEnumerator WaitThenStart()
    {
        yield return new WaitForSeconds(0.2f);
        if(infoing == false)
        {
            currentlife++;
        }
        Life();

    }

    public void Trascend()
    {
        if (scriptA.value >= 0)
        {
            Inheritance(scriptA, scriptA.value);
        }
        else if (scriptA.value < 0)
        {
            Inheritance(scriptA, -scriptA.value);
        }
        if (scriptC.value >= 0)
        {
            Inheritance(scriptC, scriptC.value);
        }
        else if (scriptC.value < 0)
        {
            Inheritance(scriptC, -scriptC.value);
        }
        names.GiveName();
        infoing= true;
        StartCoroutine(GiveInfo());
        //spr.color = sepia;
        infoimg.color = Visible;
      /*  if (scriptB.value >= 0)
        {
            Inheritance(scriptB, scriptB.value);
        }
        else if (scriptB.value < 0)
        {
            Inheritance(scriptB, -scriptB.value);
        }*/
    }

    IEnumerator GiveInfo()
    {
        yield return new WaitForSeconds(1.5f);
        
        infoimg.color = noColor;
      //  spr.color = Visible;
        infoing = false;

    }

    public void Inheritance(Valores valoractual, int min)
    {
        uporlow = Random.Range(min, 7);
        result = Random.Range(0, 3);
        if(uporlow >= 6)
        {
            if (valoractual.value > 0) { valoractual.value += result; }
            if (valoractual.value <= 0) { valoractual.value -= result; }
        }
        if (uporlow <5)
        {
            if (valoractual.value > 0) { valoractual.value -= result; }
            if (valoractual.value <= 0) { valoractual.value += result; }
        }

    }
}
