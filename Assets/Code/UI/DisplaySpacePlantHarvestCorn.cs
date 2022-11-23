using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisplaySpacePlantHarvestCorn : MonoBehaviour
{
    private SpriteRenderer sRenderer;
	private Color spriteColor;
	private float alpha;
	
	private const float fadeTimeMax = 5f;
	private float fadeTime;
	
    void Start()
    {
        sRenderer = GetComponent<SpriteRenderer>();
		spriteColor = sRenderer.color;
        alpha = spriteColor.a;
		sRenderer.enabled = false;
		fadeTime = fadeTimeMax;
    }
	
    void Update()
    {
        if (GlobalVariables.gameStarted) {
			sRenderer.enabled = true;
			if (fadeTime <= 0) {
				fadeTime = 0;
				if (alpha > 0) {
					alpha -= (Time.deltaTime * 2f);
					spriteColor.a = alpha;
					sRenderer.color = spriteColor;
				}
				else {
					Destroy(gameObject);
				}
			}
			else {		
				fadeTime -= Time.deltaTime;
			}
		}
    }
}
