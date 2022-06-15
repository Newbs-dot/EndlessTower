using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;
public class GameOverScreen : MonoBehaviour
{
    public TextMeshProUGUI pointsText;
    public TextMeshProUGUI goldText;
    public TextMeshProUGUI timeText;
    
    public void Setup(int score, int goldScore, float timeScore){
        gameObject.SetActive(true);
        pointsText.text = score.ToString();
        goldText.text = goldScore.ToString();
        timeText.text = timeScore.ToString("F2");
        Time.timeScale = 0;
    }

    public void RestartButton(){
        SceneManager.LoadScene("Game");
        EndLevelTrigger.IsGameLosed = false;
        EndLevelTrigger.IsLevelEnded = false;
        Time.timeScale = 1;
    }

    public void ExitButton(){
        SceneManager.LoadScene("Main Menu");
    }

}
