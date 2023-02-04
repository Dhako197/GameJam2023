using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupValor : MonoBehaviour
{
    public GameObject valorA;
    public GameObject valorB;
    public GameObject valorC;
    Valores scriptA;
    Valores scriptB;
    Valores scriptC;
    // Start is called before the first frame update
    void Start()
    {
        scriptA = valorA.gameObject.GetComponent<Valores>();
        scriptB = valorB.gameObject.GetComponent<Valores>();
        scriptC = valorC.gameObject.GetComponent<Valores>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.CompareTag("A1"))
        {
            scriptA.value -= 1;
            Destroy(col.gameObject);
        }
        if (col.gameObject.CompareTag("A2"))
        {
            scriptA.value += 1;
            Destroy(col.gameObject);
        }
        if (col.gameObject.CompareTag("B1"))
        {
            scriptB.value -= 1;
            Destroy(col.gameObject);
        }
        if (col.gameObject.CompareTag("B2"))
        {
            scriptB.value += 1;
            Destroy(col.gameObject);
        }
        if (col.gameObject.CompareTag("C1"))
        {
            scriptC.value -= 1;
            Destroy(col.gameObject);
        }
        if (col.gameObject.CompareTag("C2"))
        {
            scriptC.value += 1;
            Destroy(col.gameObject);
        }
    }
}
