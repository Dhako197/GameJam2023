using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    static int playerScore;
    public Text txt;

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
        txt.text = "llevas: " + playerScore.ToString() + " a�os";
    }

    IEnumerator Onesecond()
    {
        yield return new WaitForSeconds(0.2f);
        playerScore++;
        StartCoroutine(Onesecond());
    }
}
