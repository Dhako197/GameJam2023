using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PwrQuemar : MonoBehaviour
{
    
    public GameObject ControllerA;
    Valores scriptA;
    PowerCooldown cooldownA;
    public float cost;

    public GameObject llamarada;
    private bool activePower;

    // Start is called before the first frame update
    void Start()
    {
        scriptA = ControllerA.gameObject.GetComponent<Valores>();
        cooldownA = ControllerA.gameObject.GetComponent<PowerCooldown>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q) && scriptA.one == true && cooldownA.slide1.value >= cost && activePower == false)
        {
            cooldownA.slide1.value -= cost;
            //quemada
            activePower = true;
            Instantiate(llamarada, gameObject.transform);
            StartCoroutine(waitTiempo(0.5f));
        }
    }
    IEnumerator waitTiempo(float i)
    {
        yield return new WaitForSeconds(i);       
        Debug.Log("desactiva poder");      
        activePower = false;
    }
}
