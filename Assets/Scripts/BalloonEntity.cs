using UnityEngine;
using UnityEngine.Splines;

public class BloonEntity : MonoBehaviour
{
    public BloonData data; // Drag your Red_Bloon file here
    private float distancePercentage = 0;
    private SplineContainer path;

    void Start()
    {
        path = GameObject.FindGameObjectWithTag("Track").GetComponent<SplineContainer>();
    }

    void Update()
    {
        if (path == null) return;

        // Move based on the speed in the Data file
        float pathLength = path.CalculateLength();
        distancePercentage += (data.speed * Time.deltaTime) / pathLength;
        
        transform.position = (Vector3)path.EvaluatePosition(distancePercentage);

        if (distancePercentage >= 1f) {
            // Logic for losing lives
            Destroy(gameObject);
        }
    }

    public void TakeDamage(int damage)
    {
        // Simple pop logic
        if (data.nextBloon != null)
        {
            // Spawn the next layer (e.g., Red) at the same position
            SpawnNextLayer();
        }
        Destroy(gameObject);
    }

    void SpawnNextLayer() {
        // Instantiate data.nextBloon.prefab at current position
    }
}