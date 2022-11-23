using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DisplayVersion : MonoBehaviour
{
    public TMP_Text text;
	
    void Update()
    {
        if (!GlobalVariables.gameStarted) {
			text.enabled = true;
		}
		else {
			text.enabled = false;
		}
    }
}
