using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    [Header("Player Status")]
    public int money = 200; // Starting money
    public int lives = 100; // Starting lives

    void Awake()
    {
        // Singleton pattern
        if (Instance == null) Instance = this;
        else Destroy(gameObject);
    }

    public void AddMoney(int amount)
    {
        money += amount; // Increase money => Connect to UI later
        Debug.Log($"Money: {money}"); 
    }

    public void TakeDamage(int damage)
    {
        lives -= damage; // Decrase lives => Connect to UI later
        Debug.Log($"Lives: {lives}");
        if (lives <= 0) Debug.Log("Game Over!");
    }
}