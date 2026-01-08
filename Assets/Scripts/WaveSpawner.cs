using UnityEngine;

public class WaveSpawner : MonoBehaviour
{
    public Transform[] pathWaypoints; // Set in Inspector
    public BalloonData startBalloonData; 
    public float spawnInterval = 1.0f; // Time between spawns

    void Start()
    {
        InvokeRepeating("SpawnBalloon", 1f, spawnInterval); // Start spawning balloons
    }

    void SpawnBalloon()
    {
        //Instantiate the starting balloon at the beginning of the path
        GameObject bloon = Instantiate(startBalloonData.modelPrefab, pathWaypoints[0].position, Quaternion.identity); 
        
        Balloon balloonScript = bloon.GetComponent<Balloon>();
        balloonScript.data = startBalloonData; // Assign data

        BalloonMovement moveScript = bloon.GetComponent<BalloonMovement>(); 
        moveScript.SetupPath(pathWaypoints); 
    }
}