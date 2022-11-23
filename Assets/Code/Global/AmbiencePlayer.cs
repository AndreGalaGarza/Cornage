using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmbiencePlayer : MonoBehaviour
{
	private float nightPercent = 0f;
	private float maxVolume = 0f;
	private AudioSource audioSource;
	private bool m_Play;
	
    void Start()
    {
		m_Play = true;
        nightPercent = NightBackground.alpha / NightBackground.MAX_FADE;
		audioSource = GetComponent<AudioSource>();
    }
	
    void Update()
    {
		// Press N to mute/unmute ambience
		if (Input.GetKeyDown(KeyCode.N))
		{
			// Mute
			if (m_Play)
			{
				audioSource.Stop();
				m_Play = false;
			}
			// Unmute
			else if (!m_Play)
			{
				audioSource.Play();
				m_Play = true;
			}
		}
		
		// Adjust volume of ambience depending on time of day
		nightPercent = NightBackground.alpha / NightBackground.MAX_FADE;
		
		if (gameObject.name == "NightAmbiencePlayer") {
			maxVolume = 0.32f;
			audioSource.volume = nightPercent * maxVolume;
		}
        else if (gameObject.name == "DayAmbiencePlayer") {
			maxVolume = 0.58f;
			audioSource.volume = (1f - nightPercent) * maxVolume;
		}
    }
}
