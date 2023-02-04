using System.Collections;
using System.Collections.Generic;
using System.Linq.Expressions;
using UnityEngine;
using UnityEngine.Playables;

public class Waves : MonoBehaviour
{
    public float maxX;
    public float maxY;
    public float minX;
    public float minY;
    public float timeBetweenSpawn;
    private float spawnTime;
    private int temp = 0;
    private float valorAnterior;
    
    Queue<float> Estados= new Queue<float>();
    private float tiempoEstados = 30f;
    public GameObject[] estadosImagenes;

    private static Waves instance;
    public static Waves Intance { get { return instance; } }

    

    private void Start()
    {
        for(int i = 0; i < 4; i++)
        {
            float randomEstado = Random.Range(0, 6);
            if(i >= 1)
            {
                if(randomEstado ==0 && valorAnterior ==1 || randomEstado == 1 && valorAnterior == 0)
                {
                    randomEstado = Random.Range(2, 4);
                }
                else if(randomEstado==2 && valorAnterior==3 || randomEstado == 3 && valorAnterior == 2)
                {
                    randomEstado = Random.Range(4, 6);
                }
                else if(randomEstado == 4 && valorAnterior == 5 || randomEstado == 5 && valorAnterior == 4)
                {
                    randomEstado = Random.Range(0, 2);
                }
            }
            Estados.Enqueue(randomEstado);
            valorAnterior= randomEstado;
            Debug.Log(randomEstado);
            
        }

        foreach(float c in Estados)
        {
            
            estadosImagenes[temp].transform.GetChild((int)c).gameObject.SetActive(true);
            Debug.Log(temp);
            temp = temp + 1;
        }
    }
    private void Update()
    {
        tiempoEstados -= Time.deltaTime;
        if(tiempoEstados <= 0)
        {
            ActualizacionEstados();
            tiempoEstados += 30f;
        }
        if(Time.time > spawnTime)
        {
            Spawn();
            spawnTime = Time.time + timeBetweenSpawn;
        }
           
    }

    void Spawn()
    {
        float randomX = Random.Range(minX, maxX);
        float randomY= Random.Range(minY, maxY);
        Debug.Log("Si genrea");

        float randomPlatform = Random.Range(1, 6);

        switch (randomPlatform) { 
            case 1:

           PlataformaBasicaPool.Instance.Get().transform.position = new Vector2(randomX, randomY);
            break;

            case 2:
            DestroyPool.Instance.Get().transform.position = new Vector2(randomX,randomY); break;


            case 3:
                RigidaPool.Instance.Get().transform.position= new Vector2(randomX,randomY); break;

            case 4:

                PlataformaBasicaPool.Instance.Get().transform.position = new Vector2(randomX, randomY);
                break;

            case 5:
                DestroyPool.Instance.Get().transform.position = new Vector2(randomX, randomY); break;

            default: break;
        }


       // velocidadPlataformas -= 0.1f;

    }
    void ActualizacionEstados()
    {


        foreach (GameObject g in estadosImagenes) 
        {
          for(int i= 0; i< g.transform.childCount; i++)
          {
                g.transform.GetChild(i).gameObject.SetActive(false);
          }
        }

        Estados.Dequeue();
        float randomEstado = Random.Range(0, 6);

        if (randomEstado == 0 && valorAnterior == 1 || randomEstado == 1 && valorAnterior == 0)
        {
            randomEstado = Random.Range(2, 4);
        }
        else if (randomEstado == 2 && valorAnterior == 3 || randomEstado == 3 && valorAnterior == 2)
        {
            randomEstado = Random.Range(4, 6);
        }
        else if (randomEstado == 4 && valorAnterior == 5 || randomEstado == 5 && valorAnterior == 4)
        {
            randomEstado = Random.Range(0, 2);
        }

        Estados.Enqueue(randomEstado);
        valorAnterior = randomEstado;

        temp = 0;
        foreach (float c in Estados)
        {

            estadosImagenes[temp].transform.GetChild((int)c).gameObject.SetActive(true);
            Debug.Log(temp);
            temp = temp + 1;
        }

    }
}
