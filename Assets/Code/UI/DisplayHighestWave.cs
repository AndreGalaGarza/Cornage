using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DisplayHighestWave : MonoBehaviour
{
	public TMP_Text text;
	
    void Update()
    {
        if (!GlobalVariables.gameStarted) {
			text.enabled = true;
			text.SetText("Highest Wave: " + GlobalVariables.highestWave.ToString());
		}
		else {
			text.enabled = false;
		}
    }
}
