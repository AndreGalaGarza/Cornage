using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisplayStartScreen : MonoBehaviour
{
    private SpriteRenderer sRenderer;
	private Color spriteColor;
	private float alpha;
	
	private float squishSpeed = 3f;
	private float squishMultiplier = 1f;
	private const float sizeMultiplier = 1f;
	
	private float x = 0f;
	private float squishFactor = 0f;
	private float size = 0f;
	
    void Start()
    {
        sRenderer = GetComponent<SpriteRenderer>();
		spriteColor = sRenderer.color;
        alpha = spriteColor.a;
    }

    void Update()
    {
		if (!GlobalVariables.gameStarted) {
			sRenderer.enabled = true;
		}
		else {
			if (alpha > 0)
			{
				alpha -= Time.deltaTime * 2f;
				spriteColor.a = alpha;
				sRenderer.color = spriteColor;
			}
			else {
				alpha = 0;
				sRenderer.enabled = false;
				transform.localScale = new Vector3(1, 1, 1);
			}
		}
    }
	
    void FixedUpdate()
    {
		if (sRenderer.enabled && gameObject.name == "Logo") {
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
    }
}
