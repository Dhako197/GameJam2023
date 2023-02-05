using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DisplayName : MonoBehaviour
{
    public Text display;
    public string lastname;
    public bool final;
    public string[] firstnames = new string[20];
    int random;
    // Start is called before the first frame update
    void Start()
    {
        lastname = PlayerPrefs.GetString("familyname");
        if (final == true)
        {
            display.text = "Familia " + lastname;
        }
        else
        {
            GiveName();
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void GiveName()
    {
        random = Random.Range(0, 19);
        display.text = firstnames[random] + " " + lastname;
    }
}
