using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NightBackground : MonoBehaviour
{
	private SpriteRenderer sRenderer;
	private Color spriteColor;
	public static float alpha;
	private bool isNight;
	private bool changingTime;
	private bool timeChanged;
	public const float MAX_FADE = 0.75f;
	
    void Start()
    {
        sRenderer = GetComponent<SpriteRenderer>();
		spriteColor = sRenderer.color;
		// Initialize alpha transparency to 0
		alpha = 0f;
		spriteColor.a = alpha;
		sRenderer.color = spriteColor;
		isNight = false;
		changingTime = false;
    }
	
    void Update()
    {
		// Start changing time of day 7 seconds in advance
        if (GlobalVariables.waveTime <= 7) {
			if (!changingTime && !timeChanged) {
				changingTime = true;
			}
		}
		else {
			timeChanged = false;
		}
		
		if (changingTime) {
			if (!isNight) {
				// Switch from day to night
				if (alpha < MAX_FADE) {
					alpha += (Time.deltaTime * 0.15f);
				}
				else {
					alpha = MAX_FADE;
					isNight = true;
					changingTime = false;
					timeChanged = true;
				}
			}
			else {
				// Switch from night to day
				if (alpha > 0f) {
					alpha -= (Time.deltaTime * 0.15f);
				}
				else {
					alpha = 0f;
					isNight = false;
					changingTime = false;
					timeChanged = true;
				}
			}
		}
		
		spriteColor.a = alpha;
		sRenderer.color = spriteColor;
    }
}
