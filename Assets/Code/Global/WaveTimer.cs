using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveTimer : MonoBehaviour
{
	private float secondsTimer = 1f;
	
	private AudioSource audioSource;
	private AudioClip ChaChing;
	
	void Start()
	{
		audioSource = GetComponent<AudioSource>();
		ChaChing = Resources.Load<AudioClip>("Audio/ChaChing");
	}
	
    void Update()
    {
		if (GlobalVariables.gameStarted) {
			if (secondsTimer > 0) {
				secondsTimer -= Time.deltaTime;
			}
			else {
				secondsTimer = 1f;
				GlobalVariables.waveTime -= 1;
			}
		}
		
		if (GlobalVariables.waveTime == 0) {
			if (GlobalVariables.timeOfDay == "day") {
				// Switch from day to night
				GlobalVariables.timeOfDay = "night";
				GlobalVariables.wave += 1;
				GlobalVariables.waveTime = GlobalVariables.NIGHT_LENGTH;
			}
			else {
				// Switch from night to day
				if (GlobalVariables.playerMoney
					>= GlobalVariables.moneyQuota) {
					// Cha-ching!
					audioSource.PlayOneShot(ChaChing, 1f);
					PlayerHealth.HP = 3;
					GlobalVariables.timeOfDay = "day";
					GlobalVariables.waveTime = GlobalVariables.DAY_LENGTH;
					GlobalVariables.playerMoney = 0;
					
					// Gradually increase moneyQuotaIncrement exponentially
					if (GlobalVariables.wave >= 2) {
						GlobalVariables.moneyQuotaIncrement =
							(int)(GlobalVariables.moneyQuotaIncrement * 1.25f);
					}
					GlobalVariables.moneyQuota +=
						GlobalVariables.moneyQuotaIncrement;
				}
				else {
					GlobalVariables.outtaCash = true;
					PlayerHealth.HP = 0;
				}
			}
		}
		
		if (PlayerHealth.HP == 0) {
			Destroy(this);
		}
    }
}
