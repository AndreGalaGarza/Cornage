using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisplayEToSellCorn : MonoBehaviour
{
	private SpriteRenderer sRenderer;
	
    void Start()
    {
        sRenderer = GetComponent<SpriteRenderer>();
    }
	
    void Update()
    {
        if (GlobalVariables.timeOfDay == "night"
			&& GlobalVariables.playerMoney < GlobalVariables.moneyQuota
			&& GlobalVariables.waveTime <= 10
			&& PlayerHealth.HP > 0) {
			sRenderer.enabled = true;
		}
		else {
			sRenderer.enabled = false;
		}
    }
}
