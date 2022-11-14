using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CornFullyGrownIcon : MonoBehaviour
{
	private float squishSpeed = 3f;
	private float squishMultiplier = 1f;
	private const float sizeMultiplier = 1f;
	
	private float x = 0f;
	private float squishFactor = 0f;
	private float size = 0f;
	
    void FixedUpdate()
    {
        // Squish transform using cosine equation
		x += Time.fixedDeltaTime * squishSpeed;
		if (x >= 2f * Mathf.PI) {
			x = 0;
		}
		squishFactor = ((1f/10f * squishMultiplier) * Mathf.Cos(x)) + (9f/10f);
		size = squishFactor * sizeMultiplier;
		transform.localScale = new Vector3(size, size, 1);
    }
}
