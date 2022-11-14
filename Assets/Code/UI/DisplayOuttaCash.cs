using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisplayOuttaCash : MonoBehaviour
{
    private float squishSpeed = 3f;
	private float squishMultiplier = 1f;
	private const float sizeMultiplier = 3f;
	
	private float x = 0f;
	private float squishFactor = 0f;
	private float size = 0f;
	
    void FixedUpdate()
    {
		if (GlobalVariables.outtaCash) {
			GetComponent<SpriteRenderer>().enabled = true;
			// Squish transform using cosine equation
			x += Time.fixedDeltaTime * squishSpeed;
			if (x >= 2f * Mathf.PI) {
				x = 0;
			}
			squishFactor = ((1f/15f * squishMultiplier)
				* Mathf.Cos(x)) + (14f/15f);
			size = squishFactor * sizeMultiplier;
			transform.localScale = new Vector3(size, size, 1);
		}
		else {
			GetComponent<SpriteRenderer>().enabled = false;
			transform.localScale =
				new Vector3(sizeMultiplier, sizeMultiplier, 1);
		}
    }
}
