using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmbiencePlayer : MonoBehaviour
{
	private float nightPercent = 0f;
	private float maxVolume = 0f;
	private AudioSource audioSource;
	
    void Start()
    {
        nightPercent = NightBackground.alpha / NightBackground.MAX_FADE;
		audioSource = GetComponent<AudioSource>();
    }
	
    void Update()
    {
		nightPercent = NightBackground.alpha / NightBackground.MAX_FADE;
		
		if (gameObject.name == "NightAmbiencePlayer") {
			maxVolume = 0.7f;
			audioSource.volume = nightPercent * maxVolume;
		}
        else if (gameObject.name == "DayAmbiencePlayer") {
			maxVolume = 1f;
			audioSource.volume = (1f - nightPercent) * maxVolume;
		}
    }
}
