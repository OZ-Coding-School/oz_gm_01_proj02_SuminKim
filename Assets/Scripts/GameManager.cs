using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    [Header("Player Status")]
    public int money = 200;
    public int lives = 100;

    private WaveSpawner waveSpawner;
    private bool waveInProgress = false;

    void Awake()
    {
        if (Instance == null) Instance = this;
        else Destroy(gameObject);

        waveSpawner = FindObjectOfType<WaveSpawner>();
    }

    // To start a wave
    public void StartWave()
    {
        if (waveInProgress)
            return;

        waveInProgress = true;
        waveSpawner.StartWave();
    }

    // To end a wave
    public void EndWave()
    {
        waveInProgress = false;
        waveSpawner.StopWave();
    }

    public void AddMoney(int amount)
    {
        money += amount;
        Debug.Log($"Money: {money}");
    }

    public void TakeDamage(int damage)
    {
        lives -= damage;
        Debug.Log($"Lives: {lives}");
        if (lives <= 0)
            Debug.Log("Game Over!");
    }
}
