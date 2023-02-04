using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Heritage : MonoBehaviour
{
    public float lifespan;
    public GameObject valorA;
    Valores scriptA;
    public int uporlow;
    public int result;
    // Start is called before the first frame update
    void Start()
    {
        
        scriptA = valorA.gameObject.GetComponent<Valores>();
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
        Inheritance();
        Life();
    }

    public void Inheritance()
    {
        uporlow = Random.Range(1, 4);
        result = Random.Range(0, 5);
        if(uporlow <3)
        {
            if (scriptA.value > 0) { scriptA.value += result; }
            if (scriptA.value <= 0) { scriptA.value -= result; }
        }
        if (uporlow >=3)
        {
            if (scriptA.value > 0) { scriptA.value -= result; }
            if (scriptA.value <= 0) { scriptA.value += result; }
        }
    }
}
