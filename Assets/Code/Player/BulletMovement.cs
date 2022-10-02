using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletMovement : MonoBehaviour
{
    void Update()
    {
        // TEMPORARY level boundaries
		if (transform.position.x <= -50 || transform.position.x >= 50
			|| transform.position.y <= -50 || transform.position.y >= 50) {
			Destroy(gameObject);
		}
    }
	
	void OnTriggerEnter2D(Collider2D col) {
		if (col.gameObject.tag == "Enemy") {
			Destroy(gameObject);
		}
	}
}
