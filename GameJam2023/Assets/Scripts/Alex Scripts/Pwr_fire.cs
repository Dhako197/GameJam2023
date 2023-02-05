using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pwr_fire : MonoBehaviour
{
    CircleCollider2D aro;
    Platform_behaviour plataforma;
    ParticleSystem fire;
    // Start is called before the first frame update
    void Start()
    {
        aro = gameObject.GetComponent<CircleCollider2D>();
        fire = gameObject.GetComponent<ParticleSystem>();
        fire.Play();
    }
   
    // Update is called once per frame
    void Update()
    {
        
    } 
    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Suelo"))
        {
            plataforma =collision.GetComponent<Platform_behaviour>();
            if (plataforma.type == 2)
            {
                plataforma.marchitador();
                Destroy(this.gameObject);
            }
        } 
    }
}
