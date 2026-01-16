using UnityEngine;

public class BalloonMovement : MonoBehaviour
{
    private Transform[] waypoints;          // Waypoints that define the path
    private int currentWaypointIndex = 0;   // Which waypoint we are moving toward

    [HideInInspector]
    public float moveSpeed = 2f;             // Set by Balloon.cs from BalloonData

    // Called by WaveSpawner when the balloon is created
    public void SetupPath(Transform[] path, int startIndex = 0)
    {
        waypoints = path;
        currentWaypointIndex = startIndex;
    }

    void Update()
    {
        // Safety check
        if (waypoints == null || currentWaypointIndex >= waypoints.Length)
            return;

        // Move toward the current waypoint
        transform.position = Vector3.MoveTowards(
            transform.position,
            waypoints[currentWaypointIndex].position,
            moveSpeed * Time.deltaTime
        );

        // Check if the waypoint has been reached
        if (Vector3.Distance(transform.position, waypoints[currentWaypointIndex].position) < 0.1f)
        {
            currentWaypointIndex++;

            // If this was the last waypoint, notify the Balloon
            if (currentWaypointIndex >= waypoints.Length)
            {
                GetComponent<Balloon>().ReachEnd();
            }
        }
    }

    // Used when spawning child balloons
    public int GetCurrentWaypointIndex()
    {
        return currentWaypointIndex;
    }

    public Transform[] GetWaypoints()
    {
        return waypoints;
    }

    public float GetProgress()
    {
        if (waypoints == null || waypoints.Length == 0)
            return 0f;
            
        return (float)currentWaypointIndex / (waypoints.Length - 1);
    }
}
