using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.MaterialProperty;

public class ObjectPool : MonoBehaviour
{
    public string typeOfObjectPooled;

    private List<GameObject> poolObjects = new List<GameObject>();

    public int amountToPool = 2;

    public GameObject objectToSpawn;

    void Awake()
    {
        for (int i = 0; i < amountToPool; i++)
        {
            GameObject obj = Instantiate(objectToSpawn);
            obj.SetActive(false);
            poolObjects.Add(obj);
            //TEST
            Debug.Log("pooled " + typeOfObjectPooled + poolObjects.Count);
        }
        
    }
    public GameObject GetPooledObject()
    {
        for (int i = 0; i < poolObjects.Count; i++)
        {
            if (!poolObjects[i].activeInHierarchy)
            {
                //TEST
                Debug.Log("Giving " + typeOfObjectPooled +i);
                return poolObjects[i];
            }
        }

        //TEST
        Debug.Log("null " + typeOfObjectPooled);

        return null;
    }
}
