using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class alien_spider : MonoBehaviour
{

    public float HP = 5;

    // Start is called before the first frame update
    void Start(){

        // Dies and gets destroyed if HP reaches 0
        if (HP == 0){
            Destroy(gameObject);
        }
    }

    // Update is called once per frame
    void Update(){
        
    }
}
