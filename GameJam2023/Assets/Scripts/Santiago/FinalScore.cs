using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FinalScore : MonoBehaviour
{
    public Text scoretxt;
    public int playerScore;
    // Start is called before the first frame update
    void Start()
    {
        playerScore = PlayerPrefs.GetInt("score");
        scoretxt.text = playerScore.ToString() + " años";
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
