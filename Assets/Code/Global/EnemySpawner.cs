using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
	public GameObject Enemy;
	private float enemySpawnTime = 3f;
	private float enemySpawnTimer;
	
	
	void SpawnEnemy(float xMin, float xMax, float yMin, float yMax) {
		Vector3 spawnPos;
		spawnPos = new Vector3(Random.Range(xMin, xMax),
				Random.Range(yMin, yMax), 0);
		Instantiate(Enemy, spawnPos, Quaternion.identity);
	}
	
    void Start()
    {
        enemySpawnTimer = enemySpawnTime;
    }
	
    void Update()
    {
        if (enemySpawnTimer > 0) {
			enemySpawnTimer -= Time.deltaTime;
		}
		else {
			enemySpawnTimer = enemySpawnTime;
			switch(Random.Range(0, 4)) {
				case 0:
					// Top boundary
					SpawnEnemy(-30f, 30f, 20f, 25f);
					break;
				case 1:
					// Bottom boundary
					SpawnEnemy(-30f, 30f, -25f, -20f);
					break;
				case 2:
					// Left boundary
					SpawnEnemy(-35f, -30f, -20f, 20f);
					break;
				case 3:
					// Right boundary
					SpawnEnemy(30f, 35f, -20f, 20f);
					break;
			}
		}
    }
}
