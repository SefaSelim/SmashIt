using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "EnemyStatsDatabase", menuName = "ScriptableObjects/EnemyStatsDatabase")]
public class EnemyStatsDatabase : ScriptableObject
{
    public List<EnemyStats> enemyStatsList;

    public EnemyStats GetStatsByName(string name)
    {
        foreach (EnemyStats stats in enemyStatsList)
        {
            Debug.Log("Veritabanında kontrol edilen isim: " + stats.enemyName);
            if (stats.enemyName == name)
            {
                return stats;
            }
        }

        Debug.LogError("GetStatsByName() içinde isim bulunamadı: " + name);
        return null;
    }
}
