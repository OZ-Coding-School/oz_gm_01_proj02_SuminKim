using UnityEngine;

public class BalloonMovement : MonoBehaviour
{
    private Transform[] waypoints; // Path waypoints
    private int currentWaypointIndex = 0;
    [HideInInspector] public float moveSpeed = 2f;  

    public void SetupPath(Transform[] path, int startIndex = 0)
    {
        waypoints = path;
        currentWaypointIndex = startIndex;
    }

    void Update()
    {
        if (waypoints == null || currentWaypointIndex >= waypoints.Length) return;

        // Move toward current waypoint
        transform.position = Vector3.MoveTowards(transform.position, waypoints[currentWaypointIndex].position, moveSpeed * Time.deltaTime);

        // Check if reached
        if (Vector3.Distance(transform.position, waypoints[currentWaypointIndex].position) < 0.1f)
        {
            currentWaypointIndex++;
            
            // If it was the last waypoint
            if (currentWaypointIndex >= waypoints.Length)
            {
                GetComponent<Balloon>().ReachEnd();
            }
        }
    }

    public int GetCurrentWaypointIndex() => currentWaypointIndex;
}