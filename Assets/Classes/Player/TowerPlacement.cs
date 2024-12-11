using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerPlacement : MonoBehaviour
{

    [SerializeField] private Camera PlayerCamera;
    private GameObject CurrentPlacingTower;


    // Start is called before the first frame update
    void Start(){
        
    }

    // Update is called once per frame
    void Update(){
        if (CurrentPlacingTower != null){
            Ray camray = PlayerCamera.ScreenPointToRay(Input.mousePosition);
            RaycastHit HitInfo;

            if (Physics.Raycast(camray, out HitInfo, 100f)){
                CurrentPlacingTower.transform.position = HitInfo.point;
            }

            if (Input.GetMouseButtonDown(0) && HitInfo.collider.gameObject){
                CurrentPlacingTower = null;
            }

        }
    }

    public void SetTowerToPlace(GameObject tower){
        CurrentPlacingTower = Instantiate(tower, Vector3.zero, Quaternion.identity);
    }
}
