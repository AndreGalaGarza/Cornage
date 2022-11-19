using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisplayRestartPrompt : MonoBehaviour
{
	private SpriteRenderer sRenderer;
	
    void Start()
    {
        sRenderer = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
		if (PlayerHealth.HP == 0) {
			sRenderer.enabled = true;
		}
		else {
			sRenderer.enabled = false;
		}
    }
}
