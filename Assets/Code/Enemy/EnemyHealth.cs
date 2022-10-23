using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
	private int HP;
	private int maxHP;
	
	private SpriteRenderer sRenderer;
    private Color spriteColor;
	private float H;
	private float S;
	private float V;
	
	// Saturation of spriteColor fades from 1 to (1 - fadeRange)
	private const float fadeRange = 1f;

	public GameObject EnemyParticle;
	
	void Start()
    {
		maxHP = 25;
		HP = maxHP;
		
        sRenderer = GetComponent<SpriteRenderer>();
        spriteColor = sRenderer.color;
		Color.RGBToHSV(spriteColor, out H, out S, out V);
    }

    void Update()
    {
		S = (fadeRange * ((float)HP / (float)maxHP)) + (1f - fadeRange);
		spriteColor = Color.HSVToRGB(H, S, V);
        sRenderer.color = spriteColor;
		
		if (HP <= 0) {
			// Player earns 5 cash for popping a slime
			GlobalVariables.playerMoney += 5;
			for (int i = 0; i < 7; i++) {
				Instantiate(EnemyParticle, transform.position, Quaternion.identity);
			}
			Destroy(gameObject);
		}
    }
	
	void OnTriggerEnter2D(Collider2D col) {
		if (col.gameObject.tag == "Bullet") {
			HP -= 1;
		}
	}
}
