using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Heritage : MonoBehaviour
{
    public int lifespan;
    public int currentlife;
    public bool playing;
    public GameObject valorA;
    Valores scriptA;
    public GameObject valorB;
    Valores scriptB;
    public GameObject valorC;
    Valores scriptC;
    public int uporlow;
    public int result;
    public GameObject young;
    public GameObject adult;
    public GameObject elder;
    // Start is called before the first frame update
    void Start()
    {
        
        scriptA = valorA.gameObject.GetComponent<Valores>();
        scriptB = valorB.gameObject.GetComponent<Valores>();
        scriptC = valorC.gameObject.GetComponent<Valores>();
        Life();
    }

    // Update is called once per frame
    void Update()
    {
        if (currentlife >= lifespan) { currentlife= 0; Trascend(); }
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
        currentlife++;
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
        if (scriptB.value >= 0)
        {
            Inheritance(scriptB, scriptB.value);
        }
        else if (scriptB.value < 0)
        {
            Inheritance(scriptB, -scriptB.value);
        }
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
