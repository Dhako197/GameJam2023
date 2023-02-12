using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pwr_SoftRock : MonoBehaviour
{
    bool activePlatfomrEffector;
    // Start is called before the first frame update
    public string n_Platform;
    Valores valores;
   public GameObject _gameObject;
    GameObject[] suelos;

    private void Start()
    {
        activePlatfomrEffector = false;
        _gameObject = GameObject.Find("Valor C");
        valores = _gameObject.GetComponent<Valores>();
    }

    void Update()
    {
        if (valores.one)
        {
            
            ActivatePlatform();
        }
        else if (valores.one == false)
        {
            DesactivatePlatform();
            //activePlatfomrEffector = false;
        }

    }

    void ActivatePlatform()
    {
       // Debug.Log("ActivatePlatform");
       suelos = GameObject.FindGameObjectsWithTag("Suelo");

        for (int i = 0; i < suelos.Length; i++)
        {
            if(suelos[i].name == n_Platform)
            {
                suelos[i].GetComponent<PlatformEffector2D>().enabled = true;
               
            }
        }
        
    }
    void DesactivatePlatform()
    {
        suelos = GameObject.FindGameObjectsWithTag("Suelo");

        for (int i = 0; i < suelos.Length; i++)
        {
            if (suelos[i].name == n_Platform)
            {
                suelos[i].GetComponent<PlatformEffector2D>().enabled = false;

            }
        }

    }


}
