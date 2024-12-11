using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tower : MonoBehaviour
{

    public float towerHealth = 10.0f;

    void Update(){
        if (towerHealth == 0){
            Destroy(gameObject);
        }
    }

    void OnCollisionEnter(Collision Enemy){
        if (Enemy.gameObject.tag == "Enemy"){
            while (towerHealth != 0){
                towerHealth -= 1.0f;
            }
            
        }
    }
}
