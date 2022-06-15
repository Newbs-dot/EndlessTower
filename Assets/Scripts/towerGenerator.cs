using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class towerGenerator : MonoBehaviour
{
   public GameObject towerPrefab;
   public GameObject spawnPoint;
   private BoxCollider towerColl;

   private void OnTriggerEnter(Collider other) {
        if(other.tag=="Player"){
            Instantiate(towerPrefab,spawnPoint.transform.position,Quaternion.identity);
            towerColl = GetComponent<BoxCollider>();
            towerColl.enabled = !towerColl.enabled;
        }
    
    }
    void DeleteNotVisible(Camera mainCamera){
        float dist = Vector3.Distance(mainCamera.transform.position,gameObject.transform.position);
        if (dist > 20.0f){
            Destroy(gameObject);
        }
    }
    void FixedUpdate() {
        DeleteNotVisible(Camera.main);
        
    }
    
}
