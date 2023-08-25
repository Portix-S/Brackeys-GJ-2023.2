using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelSpawner : MonoBehaviour
{
    [SerializeField] Spawner[] spawners;
    [SerializeField] Transform[] enemies;
    // Start is called before the first frame update
    void Start()
    {
        CalculateSpawns();
    }

    private void CalculateSpawns()
    {
        foreach(Spawner spawner in spawners)
        {
            int randomNum = Random.Range(0, 10);
            if(randomNum > 1)
            {
                int enemyToSpawnId = Random.Range(0, enemies.Length);
                spawner.enemyToSpawn = enemies[enemyToSpawnId];
            }
        }
    }
}
