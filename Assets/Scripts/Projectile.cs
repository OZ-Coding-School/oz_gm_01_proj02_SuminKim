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
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
