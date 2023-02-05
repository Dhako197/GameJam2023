using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PwrEscudo : MonoBehaviour
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
        if (Input.GetKeyDown(KeyCode.Q) && scriptA.two == true && cooldownA.slide2.value >= cost)
        {
            cooldownA.slide2.value -= cost;
            //quemada
        }
    }
}
