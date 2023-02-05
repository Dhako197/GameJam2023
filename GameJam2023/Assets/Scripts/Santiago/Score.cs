using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    static int playerScore;
    public Text txt;
    public Heritage herscript;

    // Start is called before the first frame update
    void Start()
    {
        playerScore = 0;
        StartCoroutine(Onesecond());
    }

    // Update is called once per frame
    void Update()
    {
        PlayerPrefs.SetInt("score", playerScore);
        txt.text = "Familia " + PlayerPrefs.GetString("familyname") + ": " + playerScore.ToString() + " años";
    }

    IEnumerator Onesecond()
    {
        yield return new WaitForSeconds(0.2f);
        if(herscript.infoing == false) { playerScore++; }
        
        StartCoroutine(Onesecond());
    }
}
