using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlobalVariables : MonoBehaviour
{
    public static int playerCorn;
	public static int playerMoney;
	public static int moneyQuota;
	public static int wave;
	public const int waveLength = 100;
	public static int waveTime;
	
    void Awake()
    {
        playerCorn = 0;
		playerMoney = 0;
		moneyQuota = 50;
		wave = 1;
		waveTime = waveLength;
    }
}