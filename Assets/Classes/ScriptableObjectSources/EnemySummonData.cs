using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NewEnemySummonData", menuName = "Create EnemySummonData")]
public class EnemySummonData : ScriptableObject{
    
    public GameObject EnemyPrefab;
    public int EnemyID;
}
