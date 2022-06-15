using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class UIcontroller : MonoBehaviour
{
    // Start is called before the first frame update
    public TextMeshProUGUI scoreText;
    public Transform player;
    public Transform startingPoint;
    int score;
    int latestScore;
    void Start()
    {
        latestScore = 0;
    }

    // Update is called once per frame
    void Update()
    {
        score = Mathf.RoundToInt(player.position.y - startingPoint.position.y);
        if(score > latestScore){
            latestScore = score;
            scoreText.text = score.ToString() +"m";
        }
        
    }
}
