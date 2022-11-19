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
	
	private AudioSource audioSource;
	private AudioClip SlimeHit;
	private AudioClip SlimeSplat1;
	private AudioClip SlimeSplat2;
	private AudioClip SlimeSplat3;
	private AudioClip SlimeSplat4;
	private AudioClip SlimeSplatBig;
	private AudioClip SlimeSplatTiny;
	
	void PlaySplatSound() {
		if (gameObject.name == "SlimeTiny(Clone)") {
			AudioSource.PlayClipAtPoint(SlimeSplatTiny,
				transform.position, 1f);
		}
		else {
			switch (Random.Range(0, 4)) {
				case 0:
					AudioSource.PlayClipAtPoint(SlimeSplat1,
						transform.position, 1f);
					break;
				case 1:
					AudioSource.PlayClipAtPoint(SlimeSplat2,
						transform.position, 1f);
					break;
				case 2:
					AudioSource.PlayClipAtPoint(SlimeSplat3,
						transform.position, 1f);
					break;
				case 3:
					AudioSource.PlayClipAtPoint(SlimeSplat4,
						transform.position, 1f);
					break;					
			}
		}
	}
	
	void Start()
    {
		rb = GetComponent<Rigidbody2D>();
		coll = GetComponent<BoxCollider2D>();
		
		// Set cash values of different types of slimes
		if (gameObject.name == "SlimeBig(Clone)") {
			maxHP = 30;
			cashValue = 30;
		}
		else if (gameObject.name == "SlimeTiny(Clone)") {
			maxHP = 3;
			cashValue = 3;
		}
		else {
			maxHP = 15;
			cashValue = 15;
		}
		HP = maxHP;
		
        sRenderer = GetComponent<SpriteRenderer>();
        spriteColor = sRenderer.color;
		alpha = spriteColor.a;
		Color.RGBToHSV(spriteColor, out H, out S, out V);
		
		audioSource = GetComponent<AudioSource>();
		SlimeHit = Resources.Load<AudioClip>("Audio/SlimeHit");
		SlimeSplat1 = Resources.Load<AudioClip>("Audio/SlimeSplat1");
		SlimeSplat2 = Resources.Load<AudioClip>("Audio/SlimeSplat2");
		SlimeSplat3 = Resources.Load<AudioClip>("Audio/SlimeSplat3");
		SlimeSplat4 = Resources.Load<AudioClip>("Audio/SlimeSplat4");
		SlimeSplatBig = Resources.Load<AudioClip>("Audio/SlimeSplatBig");
		SlimeSplatTiny = Resources.Load<AudioClip>("Audio/SlimeSplatTiny");
    }

    void Update()
    {
		S = (fadeRange * ((float)HP / (float)maxHP)) + (1f - fadeRange);
		spriteColor = Color.HSVToRGB(H, S, V);
        sRenderer.color = spriteColor;
		
		if (HP <= 0) {
			PlaySplatSound();
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
			if (HP > 1) {
				audioSource.PlayOneShot(SlimeHit, 1f);
			}
			HP -= 1;
		}
	}
}
