using UnityEngine;

public class Balloon : MonoBehaviour
{
    public BalloonData data;

    [Header("Effects")]
    public GameObject popEffectPrefab;
    public AudioClip popSound;

    private BalloonMovement movement;
    private int currentHealth;

    void Start()
    {
        movement = GetComponent<BalloonMovement>();
        currentHealth = data.health;

        movement.moveSpeed = data.speed;

        EnemyManager.Instance.RegisterEnemy(this);
    }

    public void TakeDamage(int amount)
    {
        currentHealth -= amount;
        if (currentHealth <= 0)
        {
            Pop();
        }
    }

    void Pop()
    {
        // Effects
        if (popEffectPrefab != null)
        {
            GameObject fx = Instantiate(popEffectPrefab, transform.position, Quaternion.identity);
            var main = fx.GetComponent<ParticleSystem>().main;
            main.startColor = data.bloonColor;
            Destroy(fx, 1f);
        }

        if (popSound != null)
            AudioSource.PlayClipAtPoint(popSound, transform.position);

        // Reward
        GameManager.Instance.AddMoney(data.moneyReward);

        // Spawn child
        if (data.childBalloon != null)
        {
            SpawnChild();
        }

        EnemyManager.Instance.UnregisterEnemy(this);
        Destroy(gameObject);
    }

    void SpawnChild()
    {
        GameObject childObj = Instantiate(
            data.childBalloon.modelPrefab,
            transform.position,
            transform.rotation
        );

        Balloon childBalloon = childObj.GetComponent<Balloon>();
        childBalloon.data = data.childBalloon;

        BalloonMovement childMove = childObj.GetComponent<BalloonMovement>();
        BalloonMovement parentMove = GetComponent<BalloonMovement>();

        childMove.SetupPath(
            parentMove.GetSpline(),
            parentMove.GetProgress()
        );
    }

    public void ReachEnd()
    {
        GameManager.Instance.TakeDamage(data.damageToPlayer);
        EnemyManager.Instance.UnregisterEnemy(this);
        Destroy(gameObject);
    }
}
