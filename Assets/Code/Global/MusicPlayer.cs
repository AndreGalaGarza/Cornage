using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicPlayer : MonoBehaviour
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
		// Press M to mute/unmute music
		if (Input.GetKeyDown(KeyCode.M))
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
		
		// Adjust volume of music depending on time of day
		nightPercent = NightBackground.alpha / NightBackground.MAX_FADE;
		
		if (gameObject.name == "NightMusicPlayer") {
			maxVolume = 0.57f;
			audioSource.volume = nightPercent * maxVolume;
		}
        else if (gameObject.name == "DayMusicPlayer") {
			maxVolume = 0.57f;
			audioSource.volume = (1f - nightPercent) * maxVolume;
		}
    }
}
