using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
	private const float speed = 3f;
	private float x = 0;
	private float squishFactor;
	private int squishSpeed = 2;
	
    void Update()
    {
		// Squish enemy's transform
		// using cosine equation
		x += Time.deltaTime * squishSpeed;
		if (x >= 2f * Mathf.PI) {
			x = 0;
		}
		squishFactor = ((1f/10f) * Mathf.Cos(x)) + (9f/10f);
		transform.localScale = new Vector3(2f - squishFactor, squishFactor,
			transform.localScale.z);
		
		
		
		// Enemy constantly pursues player using MoveTowards
        transform.position = Vector3.MoveTowards(transform.position,
			GameObject.FindWithTag("Player").transform.position,
			speed * Time.deltaTime);
    }
}
