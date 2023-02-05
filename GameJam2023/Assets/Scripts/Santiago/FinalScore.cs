using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FinalScore : MonoBehaviour
{
    public Text scoretxt;
    public int playerScore;
    public int generations;
    // Start is called before the first frame update
    void Start()
    {
        playerScore = PlayerPrefs.GetInt("score");
        generations = PlayerPrefs.GetInt("generations");
        scoretxt.text =  generations.ToString() + " generaciones" + "(" + playerScore.ToString() + " años) ";

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
