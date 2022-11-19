using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisplayMoreCornPrompt : MonoBehaviour
{
    private SpriteRenderer sRenderer;
    private Color spriteColor;
	public static float alpha;
	
	public const float fadeoutTimeMax = 2f;
	public static float fadeoutTime = 0f;
	
	public static AudioSource audioSource;
	public static AudioClip Buzzer;
	
	public static void NeedMoreCorn(ref float fadeoutTime,
		ref float alpha, ref AudioSource audioSource, ref AudioClip Buzzer) {
		audioSource.PlayOneShot(Buzzer, 1f);
		alpha = 1;
		fadeoutTime = fadeoutTimeMax;
	}
	
    void Start()
    {
        sRenderer = GetComponent<SpriteRenderer>();
        spriteColor = sRenderer.color;
		// Set sprite to invisible by default
        alpha = 0;
		spriteColor.a = alpha;
		sRenderer.color = spriteColor;
		
		audioSource = GetComponent<AudioSource>();
		Buzzer = Resources.Load<AudioClip>("Audio/Buzzer");
    }

    void FixedUpdate()
    {
		if (fadeoutTime > 0) {
			fadeoutTime -= Time.fixedDeltaTime;
		}
		else {
			fadeoutTime = 0;
			// Fade sprite out
			if (alpha > 0) {
				alpha -= Time.fixedDeltaTime;
			}
			else {
				alpha = 0;
			}
		}
		spriteColor.a = alpha;
		sRenderer.color = spriteColor;
    }
}
