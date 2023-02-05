using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TutorialManager : MonoBehaviour
{
    public int state;
    public string scene;
    public GameObject second;
    // Start is called before the first frame update
    void Start()
    {
        state = 0;
        second.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Advance()
    {
        if(state == 0)
        {
            second.SetActive(true);
            state = 1;
        }
        else
        {
            SceneManager.LoadScene(scene);
        }
    }
}
