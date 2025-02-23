using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    public EnemyStatsDatabase enemyStatsDatabase;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        enemyStatsDatabase.GetStatsByName("MeleeEnemy");
        DontDestroyOnLoad(gameObject); // Sahne değişse bile kalıcı olsun
    }
}
