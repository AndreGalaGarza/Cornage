using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
	private Rigidbody2D rb;
	private BoxCollider2D coll;
	
	private int HP;
	private int maxHP;
	private int cashValue;
	
	private SpriteRenderer sRenderer;
    private Color spriteColor;
	private float alpha;
	private float H;
	private float S;
	private float V;
	
	// Saturation of spriteColor fades from 1 to (1 - fadeRange)
	private const float fadeRange = 1f;

	public GameObject EnemyParticle;
	
	void Start()
    {
		rb = GetComponent<Rigidbody2D>();
		coll = GetComponent<BoxCollider2D>();
		
		if (gameObject.name == "SlimeBig(Clone)") {
			maxHP = 30;
			cashValue = 10;
		}
		else if (gameObject.name == "SlimeTiny(Clone)") {
			maxHP = 3;
			cashValue = 1;
		}
		else {
			maxHP = 15;
			cashValue = 5;
		}
		HP = maxHP;
		
        sRenderer = GetComponent<SpriteRenderer>();
        spriteColor = sRenderer.color;
		alpha = spriteColor.a;
		Color.RGBToHSV(spriteColor, out H, out S, out V);
    }

    void Update()
    {
		S = (fadeRange * ((float)HP / (float)maxHP)) + (1f - fadeRange);
		spriteColor = Color.HSVToRGB(H, S, V);
        sRenderer.color = spriteColor;
		
		if (HP <= 0) {
			// Player earns cash for popping a slime
			GlobalVariables.playerMoney += cashValue;
			for (int i = 0; i < 7; i++) {
				Instantiate(EnemyParticle, transform.position, Quaternion.identity);
			}
			Destroy(gameObject);
		}
		
		// Disintegrate during the day
		if (GlobalVariables.timeOfDay == "day")
		{
			Destroy(rb);
			Destroy(coll);
			if (alpha > 0) {
				alpha -= (Time.deltaTime * 0.8f);
				spriteColor.a = alpha;
				sRenderer.color = spriteColor;
			}
			else {
				Destroy(gameObject);
			}
		}
    }
	
	void OnTriggerEnter2D(Collider2D col) {
		if (col.gameObject.tag == "Bullet") {
			HP -= 1;
		}
	}
}
