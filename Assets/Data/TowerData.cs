using UnityEngine;

[CreateAssetMenu(fileName = "TowerData", menuName = "BTD/TowerData")]
public class TowerData : ScriptableObject
{
    [Header("Identity")]
    public string towerName;
    public GameObject modelPrefab; // The prefab that has Tower.cs and TowerShooting.cs

    [Header("Stats")]
    public float range = 5.0f; //define the range of the tower
    public float fireRate = 1.0f; // Shots per second
    public int damage = 1; // Damage per shot => Do I need a damage?
    public float rotationSpeed = 10f; // Speed at which the tower rotates to face the target

    [Header("Projectile Stats")]
    public GameObject projectilePrefab;
    public float projectileSpeed = 15f; // Speed of the projectile
    public float projectileLifetime = 4f; //How long the projectile lasts before being destroyed


    [Header("Economy")]
    public int cost = 100; // Cost to build the tower
    
    [Header("Upgrades")]
    public TowerData upgradeTower; // The data for the upgraded version of this tower
    // I have to give two options for upgrades : either have a single upgrade path 
    // (like here) or have multiple upgrade paths (like in BTD6)
}