using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FamilyName : MonoBehaviour
{
    
    public string lastname;
    public GameObject inputField;
    public GameObject manager;
    StartGame script;
    // Start is called before the first frame update
    void Start()
    {
        script = manager.gameObject.GetComponent<StartGame>();
        lastname = "";
        PlayerPrefs.SetString("familyname", lastname);
    }

    // Update is called once per frame
    void Update()
    {
        lastname = inputField.gameObject.GetComponent<Text>().text;
        PlayerPrefs.SetString("familyname", lastname);
    }


}
