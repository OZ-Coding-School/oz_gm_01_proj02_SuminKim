using UnityEngine;

public class WaveSpawner : MonoBehaviour
{
    public Transform[] pathWaypoints;
    public BalloonData startBalloonData;

    public float spawnInterval = 1.0f;
    public int balloonsPerWave = 30;

    private int spawnedCount = 0;
    private bool isSpawning = false;

    public void StartWave()
    {
        if (isSpawning)
            return;


        // Ensure no previous spawning is running
        CancelInvoke(nameof(SpawnBalloon));

        spawnedCount = 0;
        isSpawning = true;

        InvokeRepeating(nameof(SpawnBalloon), 0f, spawnInterval);
    }

    void SpawnBalloon()
    {
        if (spawnedCount >= balloonsPerWave)
        {
            StopWave();
            return;
        }

        GameObject bloon = Instantiate(
            startBalloonData.modelPrefab,
            pathWaypoints[0].position,
            Quaternion.identity
        );

        Balloon balloonScript = bloon.GetComponent<Balloon>();
        balloonScript.Initialize(startBalloonData);

        BalloonMovement moveScript = bloon.GetComponent<BalloonMovement>();
        moveScript.SetupPath(pathWaypoints);

        spawnedCount++;

        Debug.Log($"Spawned: {spawnedCount}");
    }

    public void StopWave()
    {
        CancelInvoke(nameof(SpawnBalloon));
        isSpawning = false;

        Debug.Log("Wave spawning stopped");
    }
}
