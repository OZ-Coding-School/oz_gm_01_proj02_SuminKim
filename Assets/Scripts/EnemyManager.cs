using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    public static EnemyManager Instance;

    private List<Balloon> enemies = new List<Balloon>();

    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;
    }

    public void RegisterEnemy(Balloon enemy)
    {
        if (!enemies.Contains(enemy))
            enemies.Add(enemy);
    }

    public void UnregisterEnemy(Balloon enemy)
    {
        if (enemies.Contains(enemy))
            enemies.Remove(enemy);
    }

    public List<Balloon> GetEnemies()
    {
        return enemies;
    }

    public Balloon GetNearestEnemy(Vector3 position, float range)
    {
        Balloon nearest = null;
        float shortestDistance = Mathf.Infinity;

        foreach (Balloon enemy in enemies)
        {
            if (enemy == null) continue;

            float dist = Vector3.Distance(position, enemy.transform.position);
            if (dist < shortestDistance && dist <= range)
            {
                shortestDistance = dist;
                nearest = enemy;
            }
        }

        return nearest;
    }

    public Balloon GetFirstEnemy(float range, Vector3 position)
    {
        Balloon first = null;
        float highestProgress = -1f;

        foreach (Balloon enemy in enemies)
        {
            if (enemy == null) continue;

            float dist = Vector3.Distance(position, enemy.transform.position);
            if (dist > range) continue;

            float progress = enemy.GetComponent<BalloonMovement>().GetProgress();
            if (progress > highestProgress)
            {
                highestProgress = progress;
                first = enemy;
            }
        }

        return first;
    }
}
