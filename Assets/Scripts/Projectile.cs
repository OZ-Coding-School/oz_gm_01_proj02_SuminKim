using UnityEngine;

public class Projectile : MonoBehaviour
{

    public TowerData data;
    private Transform target;
    public float speed = 15f;
    public string targetTag = "Enemy";


    public void Seek(Transform _target)
    {
        target = _target;
    }
    
    void Start()
    {
        
    }

    void Update()
    {
        
    }
    // Add more projectile behavior here (e.g., movement, collision detection)

    public void SetData(TowerData towerData)
    {
        data = towerData;
    }

    
}
