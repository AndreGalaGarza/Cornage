using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayMoneyAudio : MonoBehaviour
{
	private bool quotaMet;
	private bool warningActivated;
	private AudioSource audioSource;
	private AudioClip DingDong;
	private AudioClip EmergencySell;
	private AudioClip Warning;
	
	
    void Start()
    {
		quotaMet = false;
		warningActivated = false;
        audioSource = GetComponent<AudioSource>();
		DingDong = Resources.Load<AudioClip>("Audio/DingDong");
		EmergencySell = Resources.Load<AudioClip>("Audio/EmergencySell");
		Warning = Resources.Load<AudioClip>("Audio/Warning");
    }
	
    void Update()
    {
        if (GlobalVariables.playerMoney >= GlobalVariables.moneyQuota) {
			// Ding-dong indicating quota met should only play once
			if (!quotaMet) {
				quotaMet = true;
				audioSource.Stop();
				audioSource.PlayOneShot(DingDong, 0.15f);
			}
		}
		else {
			quotaMet = false;
			if (!warningActivated
				&& GlobalVariables.timeOfDay == "night"
				&& GlobalVariables.waveTime <= 10) {
				warningActivated = true;
				audioSource.PlayOneShot(Warning, 0.25f);
			}
		}
		
		// Reset warningActivated bool
		if (GlobalVariables.timeOfDay == "day") {
			warningActivated = false;
		}
		
		// Play EmergencySell sound
		if (Input.GetKeyDown(KeyCode.E)
			&& GlobalVariables.playerMoney < GlobalVariables.moneyQuota
			&& PlayerHealth.HP > 0
			&& GlobalVariables.playerCorn >= 75) {
			audioSource.PlayOneShot(EmergencySell, 0.3f);
		}
    }
}
