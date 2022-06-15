using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Game_Manager : MonoBehaviour
{
    public float playerHeight = 0.7f;
    public Transform Fog;
    public Transform PlayerTransform;
    public Light Sun;
    public static float DayNightCycleTime;
    
    public float DayNightCycleInSec = 30.0f;
    public float FogEndHeight;
    float FogStartHeight;
    float heightToAdd;
    float FogHeightCurrent;
    bool previshenie = false;
    float intensityToSubstract;
    float SunIntensityStart = 1.2f;
    public float SunIntensityEnd;
    void Start(){
        DayNightCycleTime = DayNightCycleInSec;
        FogStartHeight = Fog.position.y;
        heightToAdd = FogCalculate(FogStartHeight,FogEndHeight,DayNightCycleInSec);

        intensityToSubstract = SunCalculate(SunIntensityStart,SunIntensityEnd,DayNightCycleInSec);
    }
    
    void Update()
    {
        FogHeightCurrent += heightToAdd* Time.deltaTime;
        Fog.position = new Vector3(Fog.position.x,FogHeightCurrent,Fog.position.z);
        
        SunIntensityStart += intensityToSubstract * Time.deltaTime;
        Sun.intensity = SunIntensityStart;
        
        
    }

    public float FogCalculate(float StartHeight,float EndHeight,float time){
        float heightToAdd = (EndHeight - StartHeight) / (time * 5);
        return heightToAdd;
    }
    public float SunCalculate(float StartIntensity,float EndIntensity,float time){
        float intensityToSubstract = (EndIntensity - StartIntensity) / (time);
        return intensityToSubstract;
    }
    
    
}
