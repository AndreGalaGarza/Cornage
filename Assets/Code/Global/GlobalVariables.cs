using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlobalVariables : MonoBehaviour
{
    public static int playerCorn;
	public static int playerMoney;
	public static int moneyQuota;
	public static int moneyQuotaIncrement;
	public static float moneyQuotaMultiplier;
	public const int MAX_MONEY_QUOTA = 300;
	public static int wave;
	public static int highestWave = 0;
	public const int DAY_LENGTH = 20;
	public const int NIGHT_LENGTH = 60;
	public static int waveTime;
	public static string timeOfDay;
	public static float harvestCooldownTimer = 0f;
	public const float HARVEST_COOLDOWN = 0.1f;
	public static bool outtaCash;
	public static bool gameStarted;
	
    void Awake()
    {
		playerCorn = 100;
		playerMoney = 0;
		moneyQuota = 15;
		moneyQuotaIncrement = 10;
		moneyQuotaMultiplier = 1.25f;
		timeOfDay = "day";
		wave = 0;
		waveTime = DAY_LENGTH;
		outtaCash = false;
		gameStarted = false;
		
		// DEBUG: Print moneyQuota for each wave
		// for i number of waves
		/*
		int localMoneyQuota = GlobalVariables.moneyQuota;
		int localIncrement = GlobalVariables.moneyQuotaIncrement;
		float localMultiplier = GlobalVariables.moneyQuotaMultiplier;
		for (int i = 1; i <= 50; i++) {
			// Gradually increase localIncrement exponentially
			if (i >= 2) {
				if (localMultiplier > 1.00f) {
					localMultiplier -= 0.02f;
				}
				localIncrement =
					(int)(localIncrement * localMultiplier);
			}
			localMoneyQuota += localIncrement;
			if (localMoneyQuota > MAX_MONEY_QUOTA) {
				localMoneyQuota = MAX_MONEY_QUOTA;
			}
			Debug.Log("Money quota on Wave " + i + ": " + localMoneyQuota);
		}
		*/
    }
	
	void Update()
	{
		if (playerCorn < 0) {
			playerCorn = 0;
		}
		
		if (playerMoney < 0) {
			playerMoney = 0;
		}
		
		if (harvestCooldownTimer > 0f) {
			harvestCooldownTimer -= Time.deltaTime;
		}
		else {
			harvestCooldownTimer = 0f;
		}
	}
}