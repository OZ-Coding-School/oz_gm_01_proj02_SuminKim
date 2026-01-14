using UnityEngine;
using UnityEngine.Splines;

public class BalloonMovement : MonoBehaviour
{
    [HideInInspector] public float moveSpeed;
    private SplineContainer spline;
    private float progress = 0f;

    public void SetupPath(SplineContainer path, float startProgress = 0f)
    {
        spline = path;
        progress = startProgress;
    }

    void Update()
    {
        if (spline == null) return;

        float splineLength = spline.CalculateLength();
        progress += (moveSpeed * Time.deltaTime) / splineLength;

        transform.position = spline.EvaluatePosition(progress);

        if (progress >= 1f)
        {
            GetComponent<Balloon>().ReachEnd();
        }
    }

    public float GetProgress() => progress;
}
