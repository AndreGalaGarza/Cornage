using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseScreenObject : MonoBehaviour
{
	private SpriteRenderer sRenderer;
	
    void Start()
    {
        sRenderer = GetComponent<SpriteRenderer>();
		sRenderer.enabled = false;
    }
	
    void Update()
    {
        if (GlobalVariables.isPaused) {
			sRenderer.enabled = true;
		}
		else {
			sRenderer.enabled = false;
		}
    }
}
