using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    public int coinValue = 1;
    public ParticleSystem Effect;
    
    private void OnTriggerEnter(Collider other) {
        if(other.gameObject.tag == "Player"){
            UI_Script.instance.AddScore(coinValue);
            GameObject go = Instantiate(Effect.gameObject,gameObject.transform.position,Quaternion.identity);
            Destroy(go,3.0f);
            Destroy(this.gameObject);
        }
    }
    
}
