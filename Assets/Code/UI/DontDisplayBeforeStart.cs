using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DontDisplayBeforeStart : MonoBehaviour
{
    private SpriteRenderer sRenderer;
	
    void Start()
    {
        sRenderer = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
		if (!GlobalVariables.gameStarted) {
			sRenderer.enabled = false;
		}
		else {
			sRenderer.enabled = true;
		}
    }
}
