using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PwrQuemar : MonoBehaviour
{
    public GameObject ControllerA;
    Valores scriptA;
    PowerCooldown cooldownA;
    public float cost;

    // Start is called before the first frame update
    void Start()
    {
        scriptA = ControllerA.gameObject.GetComponent<Valores>();
        cooldownA = ControllerA.gameObject.GetComponent<PowerCooldown>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Q) && scriptA.one == true && cooldownA.slide1.value >= cost)
        {
            cooldownA.slide1.value -= cost;
            //quemada
        }
    }
}
