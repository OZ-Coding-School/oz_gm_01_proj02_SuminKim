using UnityEngine;

public class Projectile : MonoBehaviour
{
    private Transform target;

    [Header("Stats")]
    public float speed = 15f;
    public int damage = 1;

    private float lifetime = 4f;

    // Called by Tower right after instantiation
    public void Seek(Transform _target)
    {
        target = _target;
    }

    // Pull all combat values from TowerData (single source of balance)
    public void SetData(TowerData towerData)
    {
        speed = towerData.projectileSpeed;
        damage = towerData.damage;
        lifetime = towerData.projectileLifetime;
    }

    void Update()
    {
        // If the target is gone, this projectile has no reason to exist
        if (target == null)
        {
            Destroy(gameObject);
            return;
        }

        Vector3 dir = target.position - transform.position;
        float distanceThisFrame = speed * Time.deltaTime;

        // Prevent overshooting when very close to the target
        if (dir.magnitude <= distanceThisFrame)
        {
            HitTarget();
            return;
        }

        transform.Translate(dir.normalized * distanceThisFrame, Space.World);
    }

    void HitTarget()
    {
        // Damage is applied only if the target is a Balloon
        Balloon balloon = target.GetComponent<Balloon>();
        if (balloon != null)
        {
            balloon.TakeDamage(damage);
        }

        Destroy(gameObject);
    }

    void Start()
    {
        // Safety cleanup in case the projectile never hits anything
        Destroy(gameObject, lifetime);
    }
}
