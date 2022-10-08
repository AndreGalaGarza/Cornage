using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
	private const float speed = 2f;
	private float x = 0;
	private float squishFactor;
	private const int squishSpeed = 3;
	private float hitSquish = 0;
	
    void Update()
    {
		// Squish enemy's transform using cosine equation
		x += Time.deltaTime * squishSpeed;
		if (x >= 2f * Mathf.PI) {
			x = 0;
		}
		squishFactor = ((1f/10f) * Mathf.Cos(x)) + (9f/10f);
		
		// Also squish enemy's transform if it gets hit
		if (hitSquish > 0) {
			hitSquish -= (Time.deltaTime * 3f);
		}
		else {
			hitSquish = 0;
		}
		
		transform.localScale = new Vector3((2f - squishFactor) + hitSquish,
			squishFactor + hitSquish, transform.localScale.z);
		
		// Enemy constantly pursues player using MoveTowards
        transform.position = Vector3.MoveTowards(transform.position,
			GameObject.FindWithTag("Player").transform.position,
			speed * Time.deltaTime);
    }
	
	void OnTriggerEnter2D(Collider2D col) {
		if (col.gameObject.tag == "Bullet") {
			hitSquish = 0.3f;
		}
	}
}
