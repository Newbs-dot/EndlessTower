using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndLevelTrigger : MonoBehaviour
{
    public static bool IsLevelEnded = false;
    public static bool IsGameLosed = false;
    private void OnTriggerEnter(Collider other) {
        if(this.gameObject.tag == "Win level"){
            if(IsLevelEnded == false){
                IsLevelEnded = true;
            }
            
        }
        else if(this.gameObject.tag == "Lose level"){
            if(IsGameLosed == false){
                IsGameLosed = true;
            }
            
        }
    }
}
