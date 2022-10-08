using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
	public GameObject Enemy;
	private float enemySpawnTime = 3f;
	private float enemySpawn;
	private Vector3 spawnPos;
	
    void Start()
    {
        enemySpawn = enemySpawnTime;
    }
	
    void Update()
    {
        if (enemySpawn > 0) {
			enemySpawn -= Time.deltaTime;
		}
		else {
			enemySpawn = enemySpawnTime;
			spawnPos = new Vector3(Random.Range(-7.0f, 7.0f),
				Random.Range(-4.0f, 4.0f), 0);
			Instantiate(Enemy, spawnPos, Quaternion.identity);
		}
    }
}
