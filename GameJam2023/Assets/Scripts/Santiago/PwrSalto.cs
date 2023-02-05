using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PwrSalto : MonoBehaviour
{
    public GameObject ControllerB;
    Valores scriptB;
    PowerCooldown cooldownB;
    public float cost;

    // Start is called before the first frame update
    void Start()
    {
        scriptB = ControllerB.gameObject.GetComponent<Valores>();
        cooldownB = ControllerB.gameObject.GetComponent<PowerCooldown>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.W) && scriptB.two == true && cooldownB.slide2.value >= cost)
        {
            cooldownB.slide2.value -= cost;
            //quemada
        }
    }
}
