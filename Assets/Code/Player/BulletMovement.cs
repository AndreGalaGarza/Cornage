using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletMovement : MonoBehaviour
{
    void Update()
    {
        // Destroy object past level boundaries
		if (transform.position.x <= -35 || transform.position.x >= 35
			|| transform.position.y <= -25 || transform.position.y >= 25) {
			Destroy(gameObject);
		}
    }
	
	void OnTriggerEnter2D(Collider2D col) {
		if (col.gameObject.tag == "Enemy") {
			Destroy(gameObject);
		}
	}
}
