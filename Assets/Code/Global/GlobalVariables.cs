using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlobalVariables : MonoBehaviour
{
    public static int playerCorn;
	public static int playerMoney;
	public static int moneyQuota;
	public static int wave;
	public const int DAY_LENGTH = 30;
	public const int NIGHT_LENGTH = 90;
	public static int waveTime;
	public static string timeOfDay;
	public static float harvestCooldownTimer = 0f;
	public const float HARVEST_COOLDOWN = 0.1f;
	
    void Awake()
    {
		playerCorn = 50;
		playerMoney = 0;
		moneyQuota = 60;
		timeOfDay = "day";
		wave = 0;
		waveTime = DAY_LENGTH;
    }
	
	void Update()
	{
		if (playerCorn < 0) {
			playerCorn = 0;
		}
		
		if (harvestCooldownTimer > 0f) {
			harvestCooldownTimer -= Time.deltaTime;
		}
		else {
			harvestCooldownTimer = 0f;
		}
	}
}