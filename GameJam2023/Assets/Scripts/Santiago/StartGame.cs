using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class StartGame : MonoBehaviour
{
    public string scene;
    public bool enabled;
    string check;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void StartScene()
    {
        check = PlayerPrefs.GetString("familyname");
        if(check != "" && check != " ")
        {
            SceneManager.LoadScene(scene);
        }
        
    }
}
