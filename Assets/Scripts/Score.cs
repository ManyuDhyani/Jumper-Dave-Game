using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    [SerializeField]
    public Text ScoreText;

    private int score = 0;

    private Transform player;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindWithTag("Player").transform;
    }
    void LateUpdate () {
        playerScore();
    }

    private void playerScore(){

        if (!player){
            return;
        }

        score += Mathf.FloorToInt(Time.timeSinceLevelLoad);

        //We only need to update the text if the score changed.
        ScoreText.text = score.ToString();
        
    } 
}
