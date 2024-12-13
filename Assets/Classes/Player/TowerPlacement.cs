using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerPlacement : MonoBehaviour
{

    [SerializeField] private LayerMask PlacementCheckMask;
    [SerializeField] private LayerMask PlacementCollideMask;
    [SerializeField] private Camera PlayerCamera;
    [SerializeField] private PlayerStats PlayerStatistics;
    private GameObject CurrentPlacingTower;

    // Update is called once per frame
    void Update(){
        if (CurrentPlacingTower != null){
            Ray camray = PlayerCamera.ScreenPointToRay(Input.mousePosition);
            RaycastHit HitInfo;

            if (Physics.Raycast(camray, out HitInfo, 100f, PlacementCollideMask)){
                CurrentPlacingTower.transform.position = HitInfo.point;
            }

            if (Input.GetMouseButtonDown(0) && HitInfo.collider.gameObject != null){
                if (!HitInfo.collider.gameObject.CompareTag("Can'tPlace")){

                    BoxCollider TowerCollider = CurrentPlacingTower.gameObject.GetComponent<BoxCollider>();
                    TowerCollider.isTrigger = true;

                    Vector3 BoxCenter = CurrentPlacingTower.gameObject.transform.position + TowerCollider.center;
                    Vector3 HalfExtents = TowerCollider.size / 2;

                    if (Physics.CheckBox(BoxCenter, HalfExtents, Quaternion.identity, PlacementCheckMask, QueryTriggerInteraction.Ignore)){
                        TowerCollider.isTrigger = false;
                        CurrentPlacingTower = null;
                    }
                    
                }
            }

        }
    }

    public void SetTowerToPlace(GameObject tower){

        Turret_Tower turretTower = tower.GetComponent<Turret_Tower>();
        int TowerSummonCost = turretTower.SummonCost;
        
        if (PlayerStatistics.GetMoney() >= TowerSummonCost) {
            CurrentPlacingTower = Instantiate(tower, Vector3.zero, Quaternion.identity);
            PlayerStatistics.AddMoney(-TowerSummonCost);
        }
        else {
            Debug.Log("You need more money to purchase a " + tower.name);
        }

    }
}
