using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class PLatformsSpawner : MonoBehaviour
{
    [SerializeField]
    private List<ObjectPool> nG = new List<ObjectPool>();
    [SerializeField]
    private List<ObjectPool> bG = new List<ObjectPool>();
    [SerializeField]
    private List<ObjectPool> rG = new List<ObjectPool>();

    void Start()
    {
        Spawn();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            Spawn();
        }
    }

    //Spawn the groups of platforms
    private void Spawn()
    {
        int groupType = Random.Range(1, 4);

        //TEST
        Debug.Log("Random number " + groupType);

        switch (groupType)
        {
            case 1:
                GameObject GroupOfPlatforms1 = nG[Random.Range(0, nG.Count)].GetPooledObject();
                if (GroupOfPlatforms1 != null)
                {
                    GroupOfPlatforms1.transform.position = transform.position;
                    GroupOfPlatforms1.SetActive(true);
                    //TEST
                    Debug.Log("Test NG");
                }
                break;

            case 2:
                GameObject GroupOfPlatforms2 = bG[Random.Range(0, bG.Count)].GetPooledObject();
                if (GroupOfPlatforms2 != null)
                {
                    GroupOfPlatforms2.transform.position = transform.position;
                    GroupOfPlatforms2.SetActive(true);
                    //TEST
                    Debug.Log("Test BG");
                }
                break;

            case 3:
                GameObject GroupOfPlatforms3 = bG[Random.Range(0, bG.Count)].GetPooledObject();
                if (GroupOfPlatforms3 != null)
                {
                    GroupOfPlatforms3.transform.position = transform.position;
                    GroupOfPlatforms3.SetActive(true);
                    //TEST
                    Debug.Log("Test BG");
                }
                break;

            default:
                break;
        }

        Move();

    }

    //to move after spawn
    private void Move()
    {
        transform.position  = new Vector2 (transform.position.x, transform.position.y + 20);
    }
}
