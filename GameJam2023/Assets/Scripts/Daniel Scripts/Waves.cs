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

    private void Update()
    {
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

        float randomPlatform = Random.Range(1, 4);

        switch (randomPlatform) { 
            case 1:

           PlataformaBasicaPool.Instance.Get().transform.position = new Vector2(randomX, randomY);
            break;

            case 2:
            DestroyPool.Instance.Get().transform.position = new Vector2(randomX,randomY); break;


            case 3:
                RigidaPool.Instance.Get().transform.position= new Vector2(randomX,randomY); break;
            default: break;
        }

    }
}
