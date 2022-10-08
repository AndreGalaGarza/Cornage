using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyParticle : MonoBehaviour
{
	private Rigidbody2D rb;
	
	private SpriteRenderer sRenderer;
    private Color spriteColor;
	private float alpha;
	
	private float timeUntilFade = 0.25f;
	
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
		rb.velocity = new Vector2(Random.Range(-4f, 4f), Random.Range(5f, 7f));
		
		sRenderer = GetComponent<SpriteRenderer>();
        spriteColor = sRenderer.color;
        alpha = spriteColor.a;
    }
	
	void Update()
    {
		timeUntilFade -= Time.deltaTime;
		if (timeUntilFade <= 0) {
			timeUntilFade = 0;	
			if (alpha > 0) {
				alpha -= (Time.deltaTime * 3f);
				spriteColor.a = alpha;
				sRenderer.color = spriteColor;
			}
			else {
				Destroy(gameObject);
			}
		}
    }
}
