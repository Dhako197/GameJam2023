using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RaizPool : MonoBehaviour
{
    public GameObject platformPrefab;
    public GameObject platformPrefab2;
    public GameObject platformPrefab3;
    public int initialAmount = 10;

    List<GameObject> platforms = new List<GameObject>();
    List<GameObject> platforms2 = new List<GameObject>();
    List<GameObject> platforms3 = new List<GameObject>();

    private static RaizPool instance;
    public static RaizPool Instance { get { return instance; } }



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
            GameObject go2 = Instantiate(platformPrefab2);
            GameObject go3 = Instantiate(platformPrefab3);
            go.SetActive(false);
            go2.SetActive(false);
            go3.SetActive(false);

            platforms.Add(go);
            platforms2.Add(go2);
            platforms3.Add(go3);
        }
    }
    public GameObject Get()
    {
        GameObject ret;

         int ram = Random.Range(0, 4);

        switch (ram)
        {
            case 0:
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
                
             case 1:
                if (platforms2.Count > 0)
                {
                    ret = platforms[platforms2.Count - 1];
                    platforms2.RemoveAt(platforms2.Count - 1);
                }
                else
                {
                    ret = Instantiate(platformPrefab2);
                }

                ret.SetActive(true);
                return ret;
                case 2:
                if (platforms3.Count > 0)
                {
                    ret = platforms3[platforms3.Count - 1];
                    platforms3.RemoveAt(platforms3.Count - 1);
                }
                else
                {
                    ret = Instantiate(platformPrefab3);
                }


                ret.SetActive(true);
                return ret;
            default: return null;
        }

       
    }
    public void Return(GameObject go)
    {
        go.SetActive(false);
        platforms.Add(go);
    }
}
