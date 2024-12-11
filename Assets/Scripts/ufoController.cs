using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ufoController : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        MoveGameObject();
    }

    void MoveGameObject(){
        
        transform.position = new Vector3(65, transform.position.y, transform.position.z);
    }
}
