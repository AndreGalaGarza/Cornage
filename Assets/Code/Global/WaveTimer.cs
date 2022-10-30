using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveTimer : MonoBehaviour
{
	private float secondsTimer = 1f;
	
    void Update()
    {
        if (secondsTimer > 0) {
			secondsTimer -= Time.deltaTime;
		}
		else {
			secondsTimer = 1f;
			GlobalVariables.waveTime -= 1;
		}
		
		if (GlobalVariables.waveTime == 0) {
			if (GlobalVariables.timeOfDay == "day") {
				GlobalVariables.timeOfDay = "night";
				GlobalVariables.wave += 1;
				GlobalVariables.waveTime = GlobalVariables.NIGHT_LENGTH;
			}
			else {
				GlobalVariables.timeOfDay = "day";
				GlobalVariables.waveTime = GlobalVariables.DAY_LENGTH;
				GlobalVariables.playerMoney = 0;
				GlobalVariables.moneyQuota += 20;
			}
		}
    }
}
