using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PwrEscudo : MonoBehaviour
{
    public GameObject ControllerA;
    Valores scriptA;
    PowerCooldown cooldownA;
    public float cost;
    [SerializeField]
    public ParticleSystem particleShield;
 


    GameObject[] puas;
    bool activePower;

    // Start is called before the first frame update
    void Start()
    {
        particleShield = gameObject.GetComponent<ParticleSystem>();
        particleShield.Stop();
       
        activePower = false;
        scriptA = ControllerA.gameObject.GetComponent<Valores>();
        cooldownA = ControllerA.gameObject.GetComponent<PowerCooldown>();
        puas = GameObject.FindGameObjectsWithTag("Pua");
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q) && scriptA.two == true && cooldownA.slide2.value >= cost && activePower == false)
        {
            Debug.Log("GetKey");
            cooldownA.slide2.value -= cost;
            //quemada

            ActivateShiled();
        }
            
       
    }


    void ActivateShiled()
    {
        Debug.Log("Activate Pua");
        //puas = GameObject.FindGameObjectsWithTag("Pua");
        particleShield.Play();
        
        activePower = true;
        for (int i = 0; i < puas.Length; i++)
        {
            puas[i].GetComponent<CircleCollider2D>().enabled = false;
        }
        StartCoroutine(waitTiempo(5));

    }

    void DesactivateShield()
    {      

        for (int i = 0; i < puas.Length; i++)
        {
            puas[i].GetComponent<CircleCollider2D>().enabled = true;
        }

    }


    IEnumerator waitTiempo(float i)
    {

        yield return new WaitForSeconds(i);
        DesactivateShield();
        Debug.Log("desactiva poder");
        particleShield.Stop();
        activePower = false;
    }
}
