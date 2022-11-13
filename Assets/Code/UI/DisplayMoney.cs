using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisplayMoney : MonoBehaviour
{
	private SpriteRenderer sRenderer;
    private Color spriteColor;
	private float alpha;
	
	private const int fadeSpeed = 10;
	private float x = 0;
	
    void Start()
    {
		sRenderer = GetComponent<SpriteRenderer>();
        spriteColor = sRenderer.color;
        alpha = spriteColor.a;
    }
	
	void FixedUpdate()
    {
		// If player is about to run outta cash,
		// cause money icon to flash using cosine equation
		if (GlobalVariables.timeOfDay == "night"
			&& GlobalVariables.waveTime <= 10
			&& GlobalVariables.playerMoney < GlobalVariables.moneyQuota) {
			x += Time.fixedDeltaTime * fadeSpeed;
			if (x >= 2f * Mathf.PI) {
				x = 0;
			}
			alpha = ((1f/2f) * Mathf.Cos(x)) + (1f/2f);
		}
		else {
			x = 0;
			alpha = 1;
		}
		
		spriteColor.a = alpha;
		sRenderer.color = spriteColor;
    }
}
