using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
	public GameObject SlimeBasic;
	public GameObject SlimeTiny;
	public GameObject SlimeBig;
	
	private float enemySpawnTime = 5f;
	private float enemySpawnTimer;
		
	void SpawnEnemy(float xMin, float xMax, float yMin, float yMax) {
		Vector3 spawnPos = new Vector3(Random.Range(xMin, xMax),
			Random.Range(yMin, yMax), 0);
		float spawnProb = Random.Range(1, 101);
		
		// Decide which enemy type to spawn
		// Basic Slime (spawnProb = 1-75)
		if (spawnProb <= 75) {
			Instantiate(SlimeBasic, spawnPos, Quaternion.identity);
		}
		// 5 Tiny Slimes (spawnProb = 76-90)
		else if (spawnProb <= 90) {
			for (int i = 0; i < 5; i++) {
				Instantiate(SlimeTiny, spawnPos, Quaternion.identity);
			}
		}
		// Big Slime (spawnProb = 91-100)
		else {
			Instantiate(SlimeBig, spawnPos, Quaternion.identity);
		}	
	}
	
    void Start()
    {
		enemySpawnTime = GlobalFunctions.Sigmoid(GlobalVariables.wave,
			4f, 0.5f, 8f, 1f);
		enemySpawnTimer = enemySpawnTime;
    }
	
    void Update()
    {
		// Update spawn rate depending on the wave
		enemySpawnTime = GlobalFunctions.Sigmoid(GlobalVariables.wave,
			4f, 0.5f, 8f, 1f);
		
		// Spawn enemies during the night
		if (GlobalVariables.timeOfDay == "night"
			&& !GlobalVariables.outtaCash) {
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
}
