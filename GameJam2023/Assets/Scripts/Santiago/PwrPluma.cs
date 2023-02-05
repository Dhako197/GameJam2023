using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PwrPluma : MonoBehaviour
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
        if (Input.GetKeyDown(KeyCode.W) && scriptB.one == true && cooldownB.slide1.value >= cost)
        {
            cooldownB.slide1.value -= cost;
            //quemada
        }
    }
}
