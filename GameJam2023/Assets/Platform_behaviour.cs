using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Platform_behaviour : MonoBehaviour
{
    public int type;
    //Creacion de collider 2d en codigo
    BoxCollider2D bCollider;

    //atributos para plataforma destruccion
    public Sprite spritePlatfromDamege;
    SpriteRenderer spriteRenderer;

    //atributos rotación
    PlatformEffector2D platformEffector2D;
    float x;
   

    // Start is called before the first frame update
    void Start()
    {
        //Referenciacion del collider del objeto 
        bCollider = gameObject.GetComponent<BoxCollider2D>();
        //Referencia del sprite
        spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
        //tipo default
        if (type >= 4) type = 0;
        if (type == 2)
        platformEffector2D= gameObject.GetComponent<PlatformEffector2D>();
       
    }
    /*Comportamientos:
     * 1- destrucion
     * 2-pivote, rotación
     * 
     *---------------- 
     *Destruccion: Cuadno el player toca la plataforma esta se emepzará a desmoronar para luego destruirse
    */
    void Update()
    {
       // x = transform.rotation.z;
        //platformEffector2D.rotationalOffset = (-0.002*x^2) +(0.15*x+0);


    }

   
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("colision");
        //PLatform Destruction
        if (collision.CompareTag("Player") && type == 0) 
        {
            Debug.Log("compareTag");
            //cambio de srpite
            spriteRenderer.sprite = spritePlatfromDamege;
            //conteo atras
            StartCoroutine(Corrutina(2));
            //envio del objeto al pool / por ahora desactiva
            
        }
            
    }

    IEnumerator Corrutina(int i)
    {
        Debug.Log("inicia corrutina");
        yield return new WaitForSeconds(i);
        gameObject.SetActive(false);
    }
}
