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
    int colisiones = 0;


    //atributos rotación
    PlatformEffector2D platformEffector2D;

    //atributos para raices
    OtherPlayerMovement player;
    GameObject playerGaObjc;
    bool vivo;
    
    //Poder de solidez
    private bool activeSolid;
    public GameObject _gameObject;
    Valores valores;

    // Start is called before the first frame update
    void Start()
    {
        _gameObject = GameObject.Find("Valor C");
        activeSolid = false;
        valores = _gameObject.GetComponent<Valores>();

        playerGaObjc = GameObject.FindWithTag("Player");
        player=playerGaObjc.GetComponent<OtherPlayerMovement>();

        //Referencia del sprite
        //spriteRenderer = gameObject.GetComponentInChildren<SpriteRenderer>();
        //tipo default
        if (type > 3) 
            type = 0;
        //referencia del platformeffector2D
        if (type == 1) 
            platformEffector2D = gameObject.GetComponent<PlatformEffector2D>();
        
        //Para raiz. "vivo" se refiere a las raices antes de atrapar el jugador
        
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

        if (valores.two)
            activeSolid = true;
        else
            activeSolid = false;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        colisiones++;
        Debug.Log("colision");
        //Platform Destruction
        if (collision.CompareTag("Player") && type == 0 && activeSolid==false && colisiones>=2) 
        {           
             //cambio de srpite
            spriteRenderer.sprite = spriteChange0;
            //conteo atras
            StartCoroutine(Corrutina(2f));          
            
        }
        if (collision.CompareTag("Player") && type == 2 && vivo)
        {           
            //efecto negativo de raices
            player.speed = 2;
            player.jumpingPower = 20;
            //cambio de sprites
            spriteRenderer.sprite = spriteChange0;//sprite agarre
            StartCoroutine(Corrutina(2));
        }
            
    }


    IEnumerator Corrutina(float i)
    {

        Debug.Log("inicia corrutina");

        if(type == 0 )
        {
            yield return new WaitForSeconds(i+2);
            spriteRenderer.sprite = spriteChange1;
            yield return new WaitForSeconds(i+1);
            spriteRenderer.sprite = spriteChange2;
            yield return new WaitForSeconds(i-1.9f);
            gameObject.SetActive(false);

        }
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
            player.speed = 8;
            player.jumpingPower = 24;
            spriteRenderer.sprite = spriteChange1;
            vivo = false;
            
        }
    }
}
