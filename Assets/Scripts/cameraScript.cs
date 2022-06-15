using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraScript : MonoBehaviour
{
    public Transform player;
    public Transform pivot;
    public Vector3 offset;
    Quaternion startingPoint;
    private void Start() {
        startingPoint = player.rotation;
    }
    void Update()
    {
        Vector3 cameraPos = transform.position;
        Vector3 targetPos = player.position;

        float yPos = Vector3.Lerp(cameraPos, targetPos,0.03f).y;
        transform.position = new Vector3(cameraPos.x,yPos,cameraPos.z);
        
        Quaternion rotation = Quaternion.Inverse(startingPoint) * player.rotation;
        if(player.rotation != startingPoint){
            transform.RotateAround(pivot.position,Vector3.up,rotation.eulerAngles.y);
            startingPoint = player.rotation;
        }
        
        
    }
}
    
    

