using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Platform_behaviour : MonoBehaviour
{
    public int type;

    //atributos para plataforma destruccion
    public Sprite spritePlatfromDamege;
    SpriteRenderer spriteRenderer;

    //atributos rotación
    PlatformEffector2D platformEffector2D;

    //atributos para raices
    float pSepeed;
    float pJumpingPower;


    // Start is called before the first frame update
    void Start()
    {
              
        //Referencia del sprite
        spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
        //tipo default
        if (type > 2) 
            type = 0;
        if (type == 1) 
            platformEffector2D = gameObject.GetComponent<PlatformEffector2D>();

        pSepeed = OtherPlayerMovement.instance.speed;
    }
    /*Comportamientos:
     * 0- destrucion
     * 1-pivote, rotación
     * 2- Raices
     *---------------- 
     *Destruccion: Cuadno el player toca la plataforma esta se emepzará a desmoronar para luego destruirse
     *Pivote: Rotación del cuerp. Mantiene el Plantform effector mirando hacia arriba aunque gire
     *Raices: Ralentización de movimiento
    */
    void Update()
    {   
        //Mantiene la plataorma de rotación con el effector sólido en la parte sup e intangible inf
        if(type == 1){
            platformEffector2D.rotationalOffset = Mathf.Floor(-transform.localEulerAngles.z);
        }
                   

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
        if (collision.CompareTag("Player") && type == 2)
        {            
            OtherPlayerMovement.instance.speed = 2;
            OtherPlayerMovement.instance.jumpingPower = 10;
            StartCoroutine(Corrutina(2));
        }
            
    }


    IEnumerator Corrutina(int i)
    {
        Debug.Log("inicia corrutina");
        if (type == 1)
        {
            yield return new WaitForSeconds(i);
            gameObject.SetActive(false);
        }
        

        if (type == 2)
        {
            yield return new WaitForSeconds(i);
            OtherPlayerMovement.instance.speed = pSepeed;
            OtherPlayerMovement.instance.jumpingPower = pJumpingPower;
            
        }
    }
}
