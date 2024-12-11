using UnityEngine;

public class Waypoints : MonoBehaviour
{
    public static Transform[] points;

    void Awake() {
        // Transform array of waypoints
        points = new Transform[transform.childCount];

        // 
        for (int i = 0; i < transform.childCount; i++) {
            points[i] = transform.GetChild(i);
        }
    }
}
