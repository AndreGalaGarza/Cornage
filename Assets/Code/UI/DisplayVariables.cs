using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DisplayVariables : MonoBehaviour
{
	public TMP_Text text;
    void Update()
    {
		if (gameObject.name == "CornText") {
			text.SetText(GlobalVariables.playerCorn.ToString());
		}
		else if (gameObject.name == "MoneyText") {
			text.SetText(GlobalVariables.playerMoney.ToString());
		}
		else if (gameObject.name == "WaveText") {
			text.SetText("Wave " + GlobalVariables.wave.ToString());
		}
		else if (gameObject.name == "QuotaText") {
			text.SetText("/ " + GlobalVariables.moneyQuota.ToString());
		}
		else if (gameObject.name == "TimerText") {
			int minutes = GlobalVariables.waveTime / 60;
			int seconds = GlobalVariables.waveTime % 60;
			string secondsString;
			if (seconds < 10) {
				secondsString = "0" + seconds.ToString();
			}
			else {
				secondsString = seconds.ToString();
			}
			text.SetText(minutes.ToString() + ":" + secondsString);
		}
		
		if (gameObject.name == "MoneyText" ||
		gameObject.name == "QuotaText") {
			if (GlobalVariables.playerMoney >= GlobalVariables.moneyQuota) {
				text.color = Color.green;
			}
			else {
				text.color = Color.white;
			}
		}
    }
}
