using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
	public static int HP;
	private float invincibilityTime;
	private const float MAX_INVINCIBILITY_TIME = 2f;
	private bool invincible;
	
	private SpriteRenderer sRenderer;
    private Color spriteColor;
	private float alpha;
	private const int fadeSpeed = 12;
	private float x = 0;
	
	public GameObject PlayerDestroyed;
	public GameObject HatDestroyed;
	public GameObject GunDestroyed;
	public GameObject WheelbarrowDestroyed;
	public GameObject SootParticle;
	
	private AudioSource audioSource;
	private AudioClip PlayerHurt;
	private AudioClip Explosion;
	
	private void Explode() {
		AudioSource.PlayClipAtPoint(Explosion,
				transform.position, 1f);
		for (int i = 0; i < 15; i++) {
			Instantiate(SootParticle,
				transform.position, Quaternion.identity);
		}
		Instantiate(PlayerDestroyed,
			transform.position, Quaternion.identity);
		Instantiate(HatDestroyed,
			transform.position, Quaternion.identity);
		Instantiate(GunDestroyed,
			transform.position, Quaternion.identity);
		Instantiate(WheelbarrowDestroyed,
			transform.position, Quaternion.identity);
		Destroy(gameObject);
	}
	
	void Start()
	{
		HP = 3;
		invincibilityTime = MAX_INVINCIBILITY_TIME;
		invincible = false;
		
		sRenderer = GetComponent<SpriteRenderer>();
        spriteColor = sRenderer.color;
        alpha = spriteColor.a;
		
		audioSource = GetComponent<AudioSource>();
		PlayerHurt = Resources.Load<AudioClip>("Audio/PlayerHurt");
		Explosion = Resources.Load<AudioClip>("Audio/Explosion");
	}
	
    void Update()
    {
		// As a failsafe, destroy player if out of bounds
		if (transform.position.x >= 31f
		|| transform.position.x <= -31f
		|| transform.position.y >= 21f
		|| transform.position.y <= -21f) {
			HP = 0;
		}
		
		if (HP == 0)
		{
			Explode();
		}
		
		if (invincible) {
			invincibilityTime -= Time.deltaTime;
			if (invincibilityTime <= 0) {
				invincibilityTime = 0;
				invincible = false;
			}
		}
    }
	
	void FixedUpdate() {
		// Cause player to flash during invincibility
		if (invincible) {
			x += Time.fixedDeltaTime * fadeSpeed;
			if (x >= 2f * Mathf.PI) {
				x = 0;
			}
			alpha = ((1f/3f) * Mathf.Sin(x)) + (2f/3f);
		}	
		else {
			x = 0;
			alpha = 1;
		}
		spriteColor.a = alpha;
		sRenderer.color = spriteColor;
	}
	
	void OnCollisionEnter2D(Collision2D col) {
		if (!invincible && col.gameObject.tag == "Enemy") {
			invincibilityTime = MAX_INVINCIBILITY_TIME;
			invincible = true;
			HP -= 1;
			if (HP >= 1) {
				audioSource.PlayOneShot(PlayerHurt, 1f);
			}
		}
	}
}
