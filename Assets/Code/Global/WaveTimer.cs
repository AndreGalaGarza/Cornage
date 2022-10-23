using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveTimer : MonoBehaviour
{
	private float secondsTimer = 1f;
	
    void Update()
    {
        if (secondsTimer > 0) {
			secondsTimer -= Time.deltaTime;
		}
		else {
			secondsTimer = 1f;
			GlobalVariables.waveTime -= 1;
		}
		
		if (GlobalVariables.waveTime == 0) {
			GlobalVariables.wave += 1;
			GlobalVariables.waveTime = GlobalVariables.waveLength;
		}
    }
}
