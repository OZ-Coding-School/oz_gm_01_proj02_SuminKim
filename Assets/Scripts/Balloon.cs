using UnityEngine;

public class Balloon : MonoBehaviour
{
    public BalloonData data;
    
    [Header("Effects")]
    public GameObject popEffectPrefab;
    public AudioClip popSound;

    private BalloonMovement movement;

    void Start()
    {
        // Get movement component and set speed
        movement = GetComponent<BalloonMovement>();
        if (data != null) movement.moveSpeed = data.speed;
    }

    public void Pop()
    {
        // 1. Visual & Sound
        if (popEffectPrefab != null)
        {
            GameObject fx = Instantiate(popEffectPrefab, transform.position, Quaternion.identity);
            var main = fx.GetComponent<ParticleSystem>().main;
            main.startColor = data.bloonColor;
            Destroy(fx, 1f);
        }
        if (popSound != null) AudioSource.PlayClipAtPoint(popSound, transform.position);

        // 2. Rewards
        GameManager.Instance.AddMoney(data.moneyReward);

        // 3. Spawn Child
        if (data.childBalloon != null)
        {
            SpawnChild();
        }

        Destroy(gameObject);
    }

    void SpawnChild()
    {
        // Use the prefab defined in the child data
        GameObject childObj = Instantiate(data.childBalloon.modelPrefab, transform.position, transform.rotation);
        
        Balloon childBalloon = childObj.GetComponent<Balloon>();
        childBalloon.data = data.childBalloon; // Assign the data

        BalloonMovement childMove = childObj.GetComponent<BalloonMovement>();
        // Transfer path and current index
        childMove.SetupPath(FindObjectOfType<WaveSpawner>().pathWaypoints, movement.GetCurrentWaypointIndex());
    }

    public void ReachEnd()
    {
        // Player takes damage
        GameManager.Instance.TakeDamage(data.damageToPlayer);
        Destroy(gameObject);
    }

    private void OnTriggerEnter(Collider other)
    {
        // Check for projectile collision
        if (other.CompareTag("Projectile"))
        {
            Pop();
            Destroy(other.gameObject);
        }
    }
}