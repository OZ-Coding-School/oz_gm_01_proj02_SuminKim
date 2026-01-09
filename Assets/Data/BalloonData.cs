using UnityEngine;

[CreateAssetMenu(fileName = "BalloonData", menuName = "BTD/BalloonData")]
public class BalloonData : ScriptableObject
{
    [Header("Visuals")]
    public string bloonName;
    public Color bloonColor = Color.white;
    public GameObject modelPrefab; // The prefab that has Balloon.cs and BalloonMovement.cs

    [Header("Stats")]
    public float speed = 2.0f;
    public int health = 1; // You can use this for stronger balloons later
    public int moneyReward = 1;
    public int damageToPlayer = 1;

    [Header("Layers")]
    public BalloonData childBalloon; // The data for the next layer down
}