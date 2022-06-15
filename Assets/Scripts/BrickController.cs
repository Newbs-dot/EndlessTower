using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BrickController : MonoBehaviour
{
    public ParticleSystem particle;
    private void OnTriggerEnter(Collider other) {
        if(other.tag == "Player" ){
            Destroy(gameObject);
            Instantiate(particle,transform.position,Quaternion.identity);
        }
    }

}
