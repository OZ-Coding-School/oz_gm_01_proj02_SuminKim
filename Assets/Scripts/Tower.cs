using UnityEngine;

public class Tower : MonoBehaviour
{
    public TowerData data;

    [Header("References")]
    public Transform partToRotate; // The part of the tower that rotates to face the target
    public Transform firePoint; // The point from which projectiles are fired

    private Transform target;
    private float fireCountdown = 0f;

    void Start()
    {
        //Use InvokeRepeating to save performance
        InvokeRepeating(nameof(UpdateTarget), 0f, 0.5f);
    }

    void UpdateTarget()
    {
        // Find the nearest enemy within range
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");
        float shortestDistance = Mathf.Infinity;
        GameObject nearestEnemy = null;

        // Loop through all enemies to find the nearest one
        foreach (GameObject enemy in enemies)
        {
            float distanceToEnemy = Vector3.Distance(transform.position, enemy.transform.position);
            if (distanceToEnemy < shortestDistance)     //If this enemy is closer than the previously recorded closest
            {
                shortestDistance = distanceToEnemy;  //Update shortest distance
                nearestEnemy = enemy;
            }
        }

        // If the nearest enemy is within range, set it as the target
        if (nearestEnemy != null && shortestDistance <= data.range)
        {
            target = nearestEnemy.transform;
        }
        else
        {
            target = null;
        }
    }

    void Update()
    {   // If there is no target, do nothing
        if (target == null) return;

        LockOnTarget(); // Rotate tower to face target

        if (fireCountdown <= 0f) // Time to shoot
        {
            Shoot(); // Fire a projectile
            fireCountdown = 1f / data.fireRate;
        }
        fireCountdown -= Time.deltaTime;

        
    }

    void LockOnTarget() // Rotate tower to face the target
    {
        Vector3 dir = target.position - transform.position; // Direction to the target
        Quaternion lookRotation = Quaternion.LookRotation(dir); // Calculate the rotation needed to look at the target
        // Smoothly rotate towards the target (Lerp => Smooth transition)
        Vector3 rotation = Quaternion.Lerp(partToRotate.rotation, lookRotation, Time.deltaTime * data.rotationSpeed).eulerAngles;
        partToRotate.rotation = Quaternion.Euler(0f, rotation.y, 0f); // Only rotate around the Y axis
    }

    void Shoot()
    {   
        // Create a projectile at the fire point
        GameObject projObj = Instantiate(data.projectilePrefab, firePoint.position, firePoint.rotation);
        // Get the Projectile component and set its speed and target
        Projectile projScript = projObj.GetComponent<Projectile>(); //The reasony why I made Projectile.cs
        if (projScript != null)
        {
            // Set projectile speed and target
            projScript.speed = data.projectileSpeed;  // Set speed from TowerData
            projScript.Seek(target); // Set the target for the projectile
        }
    }

    void OnGizmosSelected()
    {
        // Draw the tower's range in the editor
        if (data == null) return;
        Gizmos.color = Color.grey; // Range color
        Gizmos.DrawWireSphere(transform.position, data.range); // Draw range sphere
    }

}
