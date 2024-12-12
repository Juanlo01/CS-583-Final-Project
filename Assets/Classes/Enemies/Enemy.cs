using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour{
    
    public int NodeIndex;
    public float MaxHealth;
    public float Health;
    public float Speed;
    public int ID;

    public void Init(){
        Health = MaxHealth;
        transform.position = GameLoopManager.NodePositions[0];
        NodeIndex = 0;
    }

    // Called from the bullet script
    public void TakeDamage(int damageAmount){
        Health -= damageAmount;
         Debug.Log("Enemy Took 1 damage");
    }
    
}
