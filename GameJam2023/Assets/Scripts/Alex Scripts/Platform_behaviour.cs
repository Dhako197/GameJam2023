using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Platform_behaviour : MonoBehaviour
{
    public int type;

    //atributos para plataforma destruccion
    public Sprite spriteChange0, spriteChange1, spriteChange2;
    [SerializeField]
    SpriteRenderer spriteRenderer;


    //atributos rotación
    PlatformEffector2D platformEffector2D;

    //atributos para raices
    float pSepeed;
    float pJumpingPower;
    bool vivo;


    // Start is called before the first frame update
    void Start()
    {
              
        //Referencia del sprite
        //spriteRenderer = gameObject.GetComponentInChildren<SpriteRenderer>();
        //tipo default
        if (type > 3) 
            type = 0;
        //referencia del platformeffector2D
        if (type == 1) 
            platformEffector2D = gameObject.GetComponent<PlatformEffector2D>();
        
        //Para raiz. guarda el valor orginal de la vel y salto.
        pSepeed = OtherPlayerMovement.instance.speed;
        pJumpingPower = OtherPlayerMovement.instance.jumpingPower;
        vivo = true;
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
            Debug.Log("Collision type1");
        
            //cambio de srpite
            spriteRenderer.sprite = spriteChange0;
            //conteo atras
            StartCoroutine(Corrutina(2));          
            
        }
        if (collision.CompareTag("Player") && type == 2 && vivo)
        {           
            //efecto negativo de raices
            OtherPlayerMovement.instance.speed = 2;
            OtherPlayerMovement.instance.jumpingPower = 15;
            //cambio de sprites
            spriteRenderer.sprite = spriteChange0;//sprite agarre
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
        
        //efecto raices
        if (type == 2)
        {
            //vuelta a valores normales
            yield return new WaitForSeconds(i);
            OtherPlayerMovement.instance.speed = pSepeed;
            OtherPlayerMovement.instance.jumpingPower = pJumpingPower;
            spriteRenderer.sprite = spriteChange1;
            vivo = false;
            
        }
    }
}
