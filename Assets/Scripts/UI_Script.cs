using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class UI_Script : MonoBehaviour
{
    bool GameIsPaused = false;
    float timeStart = 0;
    public TMP_Text timerText;
    public TextMeshProUGUI scoreText;
    public GameOverScreen GameWinScreen;
    public GameOverScreen GameOverScr;
    public Image DayNightImg;
    float angleToRotate;
    float imgZAngle;
    public static UI_Script instance;
    int score;
    void Start(){
        timerText.text = timeStart.ToString("F2");
        angleToRotate = AngleToRotateImg();
        
        if(instance == null){
            instance = this;
        }
    }
    
    void Update(){
        timeStart += Time.deltaTime;
        timerText.text = timeStart.ToString("F2");
        imgZAngle = DayNightImg.transform.eulerAngles.z;
        DayNightCycle(DayNightImg,imgZAngle,angleToRotate);

        if(EndLevelTrigger.IsLevelEnded == true){
            GameWinScreen.Setup(score,score*2,timeStart);
        }
        if(EndLevelTrigger.IsGameLosed == true){
            GameOverScr.Setup(score,score*2,timeStart);
        }
        
     
    }

    public void Pause(){
        if(GameIsPaused){
            Time.timeScale = 1;
            GameIsPaused = false;
        }
        else{
            Time.timeScale = 0;
            GameIsPaused = true;
        }
    }
    public void DayNightCycle(Image im,float Z_ImgRotation,float angle){
        Z_ImgRotation += angle * Time.deltaTime;
        im.transform.rotation = Quaternion.Euler(0,0,Z_ImgRotation);
    }
    public float AngleToRotateImg(){
        float angleToRotate = 180.0f;
        float DayChangeTime = Game_Manager.DayNightCycleTime;
        float angleInSec = (angleToRotate / DayChangeTime);

        return angleInSec;
    }
    public void AddScore(int coinValue){
        score+=coinValue;
        scoreText.text = score.ToString();
    }
    
}

