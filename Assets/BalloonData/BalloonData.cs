using UnityEngine;

[CreateAssetMenu(fileName = "BalloonData", menuName = "BTD/BalloonData")]
public class BalloonData : ScriptableObject
{
    [Header("Visuals")]
    public string bloonName;
    public Color bloonColor = Color.white;
    public GameObject modelPrefab;

    [Header("Stats")]
    public float speed = 1.0f;
    public int health = 1;
    public int moneyReward = 1;
    public int damageToPlayer = 1;

    [Header("Layers")]
    public BalloonData childBalloon;


}
