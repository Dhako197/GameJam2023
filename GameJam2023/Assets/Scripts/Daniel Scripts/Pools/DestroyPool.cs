using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyPool : MonoBehaviour
{
    public GameObject platformPrefab;
    public int initialAmount = 10;

    List<GameObject> platforms = new List<GameObject>();

    private static DestroyPool instance;
    public static DestroyPool Instance { get { return instance; } }

    

    public void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
        FillPoll();
    }
    void FillPoll()
    {
        for (int t = 0; t < initialAmount; t++)
        {
            GameObject go = Instantiate(platformPrefab);
            go.SetActive(false);
            platforms.Add(go);
        }
    }
    public GameObject Get()
    {
        GameObject ret;
        if (platforms.Count > 0)
        {
            ret = platforms[platforms.Count - 1];
            platforms.RemoveAt(platforms.Count - 1);
        }
        else
        {
            ret = Instantiate(platformPrefab);
        }
        ret.SetActive(true);
        return ret;
    }
    public void Return(GameObject go)
    {
        go.SetActive(false);
        platforms.Add(go);
    }
}
