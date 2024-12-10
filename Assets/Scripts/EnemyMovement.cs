using UnityEngine;
using System.Collections;

//[RequireComponent(typeof(CharacterController))]

public class Chaser : MonoBehaviour {
	
	public float speed = 20.0f;
	public float minDist = 0.5f;
	private Transform target;
	private int wavepointIndex = 0;

	// Use this for initialization
	void Start () 
	{
		// Initialize the first target waypoint
        if (Waypoints.points != null && Waypoints.points.Length > 0)
        {
            target = Waypoints.points[0];
        }

		// if no target specified, assume the player
		if (target == null) {

			if (GameObject.FindWithTag ("Tower")!=null)
			{
				target = GameObject.FindWithTag ("Tower").GetComponent<Transform>();
			}
		}
	}
	
	// Update is called once per frame
	void Update () 
	{
		if (target == null) {
    		Debug.LogWarning("Target is null.");
    		return;
		}

		// face the target
		transform.LookAt(target);

		// have chaser go towards waypoint
		transform.position = Vector3.MoveTowards(transform.position, target.position, speed * Time.deltaTime);

		// check if minDist threshhold allows enemy to go to next waypoint
		//Debug.Log($"Moving towards: {target.name}, Distance: {Vector3.Distance(transform.position, target.position)}");

		if (Vector3.Distance(transform.position, target.position) <= minDist) {
			Debug.Log("Reached waypoint, getting next...");
			GetNextWaypoint();
		} 
	}

	// Set the next waypoint of the chaser
	void GetNextWaypoint() {

		if (wavepointIndex >= Waypoints.points.Length - 1) {
			Destroy(gameObject);
			return;
		}
		wavepointIndex++;
		target = Waypoints.points[wavepointIndex];
	}

}