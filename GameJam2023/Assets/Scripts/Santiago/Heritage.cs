using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Heritage : MonoBehaviour
{
    public float lifespan;
    public GameObject valorA;
    Valores scriptA;
    public GameObject valorB;
    Valores scriptB;
    public GameObject valorC;
    Valores scriptC;
    public int uporlow;
    public int result;
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
        
    }

    public void Life()
    {
        StartCoroutine(WaitThenStart());
    }
    IEnumerator WaitThenStart()
    {
        yield return new WaitForSeconds(lifespan);
        if(scriptA.value>=0)
        {
            Inheritance(scriptA, scriptA.value);
        }
        else if(scriptA.value <0)
        {
            Inheritance(scriptA, -scriptA.value);
        }
        if(scriptC.value>=0)
        {
            Inheritance(scriptC, scriptC.value);
        }
        else if(scriptC.value <0)
        {
            Inheritance(scriptC, -scriptC.value);
        }
        if(scriptB.value>=0)
        {
            Inheritance(scriptB, scriptB.value);
        }
        else if(scriptB.value <0)
        {
            Inheritance(scriptB, -scriptB.value);

        }
        Life();
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