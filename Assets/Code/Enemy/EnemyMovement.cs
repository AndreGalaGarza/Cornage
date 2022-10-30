using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
	private float speed = 2f;
	private int squishSpeed = 3;
	private float x = 0;
	private float squishFactor;
	private float squishMultiplier;
	private float hitSquish = 0;
	
	void Start()
	{
		if (gameObject.name == "SlimeBig(Clone)") {
			speed = 1f;
			squishSpeed = 2;
			squishMultiplier = 0.7f;
		}
		else if (gameObject.name == "SlimeTiny(Clone)") {
			speed = 5f;
			squishSpeed = 10;
			squishMultiplier = 1f;
		}
		else {
			speed = 2f;
			squishSpeed = 3;
			squishMultiplier = 1f;
		}
	}
	
    void FixedUpdate()
    {
		// Squish enemy's transform using cosine equation
		x += Time.fixedDeltaTime * squishSpeed;
		if (x >= 2f * Mathf.PI) {
			x = 0;
		}
		squishFactor = ((1f/10f * squishMultiplier) * Mathf.Cos(x)) + (9f/10f);
		
		// Also squish enemy's transform if it gets hit
		if (hitSquish > 0) {
			hitSquish -= (Time.fixedDeltaTime * 3f);
		}
		else {
			hitSquish = 0;
		}
		
		transform.localScale = new Vector3((2f - squishFactor) + hitSquish,
			squishFactor + hitSquish, transform.localScale.z);
		
		// Enemy constantly pursues player using MoveTowards
        transform.position = Vector3.MoveTowards(transform.position,
			GameObject.FindWithTag("Player").transform.position,
			speed * Time.fixedDeltaTime);
    }
	
	void OnTriggerEnter2D(Collider2D col) {
		if (col.gameObject.tag == "Bullet") {
			hitSquish = 0.3f * squishMultiplier;
		}
	}
}
